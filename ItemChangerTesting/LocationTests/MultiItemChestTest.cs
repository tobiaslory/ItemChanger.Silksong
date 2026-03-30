using Benchwarp.Data;
using ItemChanger;
using ItemChanger.Locations;
using ItemChanger.Silksong.Containers;
using ItemChanger.Silksong.RawData;
using ItemChanger.Silksong.Tags;

namespace ItemChangerTesting.LocationTests;

internal class MultiItemChestTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.LocationTests,
        MenuName = "Multi-item chest",
        MenuDescription = "Tests giving various items from a spawned non-default chest in Tut_02",
        Revision = 2026032300,
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
        var surgeonKey = Finder.GetItem(ItemNames.Surgeon_s_Key)!;
        surgeonKey.AddTag(new ItemChestTypeTag() { ChestType = ChestType.CityShard });
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Multi-item chest test",
            SceneName = SceneNames.Tut_02,
            X = 133.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
            ForceDefaultContainer = false,
        }.Wrap()
         .Add(surgeonKey)
         .Add(Finder.GetItem(ItemNames.Everbloom)!)
         .Add(Finder.GetItem(ItemNames.Pale_Oil)!));
    }
}
