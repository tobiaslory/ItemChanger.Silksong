using Benchwarp.Data;
using ItemChanger.Silksong.RawData;
using ItemChanger.Silksong.StartDefs;

namespace ItemChangerTesting.LocationTests;

internal class CorpsecrestSilkSkillTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.LocationTests,
        MenuName = "Corpsecrest Silk Skill",
        MenuDescription = "Tests giving Cross Stitch from Crest_of_Shaman and autoequipping it.",
        Revision = 2026033000,
    };

    public override void Setup(TestArgs args)
    {
        StartAt(new CoordinateStartDef() { SceneName = SceneNames.Tut_05, X = 283.79f, Y = 58.77f, MapZone = GlobalEnums.MapZone.NONE });
        Profile.AddPlacement(Finder.GetLocation(LocationNames.Crest_of_Shaman)!.Wrap()
            .Add(Finder.GetItem(ItemNames.Cross_Stitch)!));
    }
}
