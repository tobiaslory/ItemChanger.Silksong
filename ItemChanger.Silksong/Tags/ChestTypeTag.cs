using ItemChanger.Locations;
using ItemChanger.Silksong.Containers;
using ItemChanger.Tags;
using ItemChanger.Tags.Constraints;

namespace ItemChanger.Silksong.Tags;

/// <summary>
/// Tag recording the original chest type for a chest location.
/// </summary>
[TagConstrainedTo<ContainerLocation>]
public class OriginalChestTypeTag : Tag
{
    public required ChestType ChestType { get; init; }
}

/// <summary>
/// Tag indicating that an item is requesting to be given a particular chest type.
/// </summary>
[ItemTag]
public class ItemChestTypeTag : Tag
{
    public required ChestType ChestType { get; init; }
}
