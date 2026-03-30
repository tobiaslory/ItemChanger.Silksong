using Benchwarp.Data;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.LocationTests;

internal class ChestLocationTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.LocationTests,
        MenuName = "Chest location",
        MenuDescription = "Tests modifying an existing chest location in Tut_01",
        Revision = 2026032300,
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Tut_01, PrimitiveGateNames.left1);
        Profile.AddPlacement(BaseLocationList.Rosary_Chest__Tut_01.Wrap()
            .Add(BaseItemList.Craftmetal));
    }
}
