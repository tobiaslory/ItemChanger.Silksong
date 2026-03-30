using ItemChanger.Locations;
using ItemChanger.Items;
using ItemChanger.Silksong.Items;
using ItemChanger.Silksong.RawData;
using ItemChanger.Silksong.Serialization;
using Silksong.FsmUtil;
using Silksong.FsmUtil.Actions;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ItemChanger.Silksong.Locations;

public class CrestCorpseLocation : AutoLocation
{
    protected override void DoLoad()
    {
        Using(new FsmEditGroup()
        {
            {new(SceneName!, "Crest Get Shrine", "Control"), HookCorpse},
            {new(SceneName!, "Music Control", "Control"), HookMusic},
        });
    }

    protected override void DoUnload() { }

    private void HookCorpse(PlayMakerFSM fsm)
    {
        FsmState checkState = fsm.MustGetState("Check Unlocked");
        checkState.RemoveActionsOfType<GetIsCrestUnlocked>();
        checkState.InsertMethod(0, () =>
        {
            if (Placement!.AllObtained())
            {
                fsm.SendEvent("UNLOCKED");
            }
        });

        FsmState crestChangeState = fsm.MustGetState("Crest Change");
        crestChangeState.RemoveActionsOfType<UnlockCrest>();
        crestChangeState.RemoveActionsOfType<AutoEquipCrestV2>();
        crestChangeState.RemoveActionsOfType<ToolsActiveStateControlV2>();
        crestChangeState.InsertLambdaMethod(0, GiveAllAndApplyCorpsecrestEffects);

        FsmState crestMsgState = fsm.MustGetState("Crest Msg");
        crestMsgState.RemoveActionsOfType<ShowToolCrestUIMsg>();

        FsmState crestGetAnticState = fsm.MustGetState("Crest Get Antic");
        crestGetAnticState.RemoveLastActionOfType<Wait>();
        crestGetAnticState.RemoveLastActionMatching(act => 
            act is SendEventByName send
            && send.sendEvent.Value == "CREST CHANGE ANTIC");
    }

    private void HookMusic(PlayMakerFSM fsm)
    {
        // Most chapels use Fade Up except for the Ruined Chapel, which uses State 1.
        FsmState? controlState = fsm.GetState("Fade Up") ?? fsm.GetState("State 1");
        // This is purely cosmetic so we can be graceful if it fails.
        if (controlState != null)
        {
            controlState.ReplaceFirstActionOfType<GetIsCrestUnlocked>(new LambdaAction { Method = () =>
            {
                if (Placement!.AllObtained())
                {
                    fsm.SendEvent("INACTIVE");
                }
            }});
        }
    }

    private void GiveAllAndApplyCorpsecrestEffects(Action callback)
    {
        Item[] newlyGrantedItems = Placement!.Items.Where(item => !item.IsObtained()).ToArray();
        GiveAll(() =>
        {
            ApplyCorpsecrestPostGrantEffects(newlyGrantedItems);
            callback();
        });
    }

    private static void ApplyCorpsecrestPostGrantEffects(Item[] newlyGrantedItems)
    {
        ToolItem? equippedSkill = newlyGrantedItems.Select(GetSilkSkillTool).FirstOrDefault(tool => tool != null);
        if (equippedSkill is null)
        {
            return;
        }

        ToolItemManager.AutoEquip(equippedSkill);
        ToolItemManager.SetActiveState(ToolsActiveStates.Active, skipAnims: true);
        ToolItemManager.ReportAllBoundAttackToolsUpdated();
    }

    private static ToolItem? GetSilkSkillTool(Item item)
    {
        if (item is not ItemChangerSavedItem { Item.Type: BaseGameSavedItem.ItemType.ToolItem } savedItem)
        {
            return null;
        }

        return item.Name switch
        {
            ItemNames.Cross_Stitch or
            ItemNames.Pale_Nails or
            ItemNames.Rune_Rage or
            ItemNames.Sharpdart or
            ItemNames.Silkspear or
            ItemNames.Thread_Storm => savedItem.Item.Value as ToolItem,
            _ => null,
        };
    }
}
