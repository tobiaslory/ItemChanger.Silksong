using Benchwarp.Data;
using ItemChanger.Enums;
using ItemChanger.Locations;
using ItemChanger.Silksong.Containers;
using ItemChanger.Silksong.Tags;
using ItemChanger.Tags;
using UnityEngine;

namespace ItemChanger.Silksong.RawData;

internal static partial class BaseLocationList
{
    private static Location CreateChestLocation(
        string name,
        string sceneName,
        string objectName,
        ChestType chestType,
        FlingType flingType = FlingType.Everywhere
    )
    {
        return new ObjectLocation()
        {
            Name = name,
            SceneName = sceneName,
            ObjectName = objectName,
            FlingType = flingType,
            Correction = Vector3.zero,
            Tags =
            [
                new OriginalContainerTag() { ContainerType = ContainerNames.Chest },
                new OriginalChestTypeTag() { ChestType = chestType },
            ],
        };
    }

    public static Location Rosary_Chest__Ant_21 => CreateChestLocation(
        LocationNames.Rosary_Chest__Ant_21,
        "ant_21",
        "Ant Chest",
        ChestType.Ant
    );

    public static Location Rosary_Chest__Bone_19 => CreateChestLocation(
        LocationNames.Rosary_Chest__Bone_19,
        "bone_19",
        "Bone Chest",
        ChestType.Bone
    );

    public static Location Rosary_Chest__Bone_East_17 => CreateChestLocation(
        LocationNames.Rosary_Chest__Bone_East_17,
        "bone_east_17",
        "Ant Chest",
        ChestType.Ant
    );

    public static Location Rosary_Chest__Bone_East_18 => CreateChestLocation(
        LocationNames.Rosary_Chest__Bone_East_18,
        "bone_east_18",
        "Ant Chest",
        ChestType.Ant
    );

    public static Location Craftmetal__Deep_Docks => CreateChestLocation(
        LocationNames.Craftmetal__Deep_Docks,
        "dock_03",
        "City Shard Chest",
        ChestType.CityShard
    );

    public static Location Rosary_Chest__Dust_05 => CreateChestLocation(
        LocationNames.Rosary_Chest__Dust_05,
        "dust_05",
        "Pilgrim Chest",
        ChestType.Pilgrim
    );

    public static Location Rosary_Chest__Hang_06_Bank_1 => CreateChestLocation(
        LocationNames.Rosary_Chest__Hang_06_Bank_1,
        "hang_06_bank",
        "Thief Scene Control/Thieves Not Here/Chest",
        ChestType.Bank
    );

    public static Location Rosary_Chest__Hang_06_Bank_2 => CreateChestLocation(
        LocationNames.Rosary_Chest__Hang_06_Bank_2,
        "hang_06_bank",
        "Thief Scene Control/Thieves Not Here/Chest (1)",
        ChestType.Bank
    );

    public static Location Rosary_Chest__Hang_06_Bank_3 => CreateChestLocation(
        LocationNames.Rosary_Chest__Hang_06_Bank_3,
        "hang_06_bank",
        "Thief Scene Control/Thieves Not Here/Chest (2)",
        ChestType.Bank
    );

    public static Location Rosary_Chest__Hang_08 => CreateChestLocation(
        LocationNames.Rosary_Chest__Hang_08,
        "hang_08",
        "Chest Scene/Chest",
        ChestType.ChestScene
    );

    public static Location Rosary_Chest__Slab_19b => CreateChestLocation(
        LocationNames.Rosary_Chest__Slab_19b,
        "slab_19b",
        "City Shard Chest",
        ChestType.CityShard
    );

    public static Location Rosary_Chest__Song_03 => CreateChestLocation(
        LocationNames.Rosary_Chest__Song_03,
        "song_03",
        "Chest Scene/Chest",
        ChestType.ChestScene
    );

    public static Location Rosary_Chest__Song_17 => CreateChestLocation(
        LocationNames.Rosary_Chest__Song_17,
        "song_17",
        "Chest Scene/Chest",
        ChestType.ChestScene
    );

    public static Location Rosary_Chest__Song_24 => CreateChestLocation(
        LocationNames.Rosary_Chest__Song_24,
        "song_24",
        "Black Thread States/Normal World/Enemy Control/Song Fencer/Chest",
        ChestType.SongFencer
    );

    public static Location Rosary_Chest__Tut_01 => CreateChestLocation(
        LocationNames.Rosary_Chest__Tut_01,
        SceneNames.Tut_01,
        "Bone Chest",
        ChestType.Bone
    );

    // Omitted for now: dock_06_church chest contains loose shard currency rather than a modeled chest item/location.
}
