using Benchwarp.Data;
using Silksong.AssetHelper.Plugin;

namespace ItemChanger.Silksong
{
    public partial class ItemChangerPlugin
    {
        private static void RequestAssets()
        {
            // Requests must be made in Awake, so we have to do this independently from setting up the host
            // Instantiating the flea container causes the ManagedAssets to be instantiated,
            // so the manual requests can be removed if the container is defined in Awake.
            AssetRequestAPI.RequestSceneAsset(SceneNames.Bone_East_05, "Flea Rescue Barrel");
            AssetRequestAPI.RequestSceneAsset(SceneNames.Dust_12, "Flea Rescue Sleeping");
            AssetRequestAPI.RequestSceneAsset(SceneNames.Ant_03, "Flea Rescue Cage");
            AssetRequestAPI.RequestSceneAsset(SceneNames.Library_01, "Flea Rescue CitadelCage");
            AssetRequestAPI.RequestSceneAsset(SceneNames.Hang_06_bank, "Thief Scene Control/Thieves Not Here/Chest");
            AssetRequestAPI.RequestSceneAsset(SceneNames.Hang_06_bank, "Thief Scene Control/Thieves Not Here/Chest (1)");
            AssetRequestAPI.RequestSceneAsset(SceneNames.Hang_06_bank, "Thief Scene Control/Thieves Not Here/Chest (2)");
            AssetRequestAPI.RequestSceneAsset(SceneNames.Tut_01, "Bone Chest");
            AssetRequestAPI.RequestSceneAsset("bone_east_17", "Ant Chest");
            AssetRequestAPI.RequestSceneAsset("ant_21", "Ant Chest");
            AssetRequestAPI.RequestSceneAsset("slab_19b", "City Shard Chest");
            AssetRequestAPI.RequestSceneAsset("dock_03", "City Shard Chest");
            AssetRequestAPI.RequestSceneAsset("dust_05", "Pilgrim Chest");
            AssetRequestAPI.RequestSceneAsset("hang_08", "Chest Scene/Chest");
            AssetRequestAPI.RequestSceneAsset("song_03", "Chest Scene/Chest");
            AssetRequestAPI.RequestSceneAsset("song_24", "Black Thread States/Normal World/Enemy Control/Song Fencer/Chest");
            AssetRequestAPI.RequestSceneAsset("dock_06_church", "Black Thread States Thread Only Variant/Normal World/City Shard Chest");
            AssetRequestAPI.RequestNonSceneAsset<QuestTargetPlayerDataBools>(
                bundleName: "dataassets_assets_assets/dataassets/questsystem/proxies.bundle",
                assetName: "Assets/Data Assets/Quest System/Proxies/FleasCollected Target.asset"
                );
        }
    }
}
