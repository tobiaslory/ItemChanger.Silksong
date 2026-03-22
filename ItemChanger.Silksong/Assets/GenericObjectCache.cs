using ItemChanger.Silksong.Util;
using Silksong.AssetHelper.ManagedAssets;

namespace ItemChanger.Silksong.Assets;

internal class GenericObjectCache<T> : IObjectCache<T>
{
    private Dictionary<string, ManagedAsset<T>> _assets = [];

    private GenericObjectCache(Dictionary<string, ManagedAsset<T>> assets)
    {
        _assets = assets;
    }

    public T GetAsset(string key)
    {
        ManagedAsset<T> asset = _assets.TryGetValue(key, out ManagedAsset<T> fromDict)
            ? fromDict
            : throw new KeyNotFoundException($"Did not find key {key} for type {typeof(T).Name}");

        asset.EnsureLoaded();
        return asset.Handle.Result;
    }

    public static GenericObjectCache<T> FromEmbeddedResource(string resourceName)
    {
        Dictionary<string, ManagedAsset<T>> assets = [];

        if (!JsonUtils.TryDeserializeEmbeddedResource(
            resourceName,
            out Dictionary<string, ManagedAssetGroup<T>.NonSceneAssetInfo>? nonSceneAssetData))
        {
            throw new ArgumentException($"Could not find embedded resource {resourceName}");
        }

        foreach ((string key, ManagedAssetGroup<T>.NonSceneAssetInfo info) in nonSceneAssetData)
        {
            assets[key] = ManagedAsset<T>.FromNonSceneAsset(assetName: info.AssetName, bundleName: info.BundleName);
        }

        return new(assets);
    }

    public void Load()
    {
        foreach (ManagedAsset<T> asset in _assets.Values)
        {
            asset.Load();
        }
    }

    public void Unload()
    {
        foreach (ManagedAsset<T> asset in _assets.Values)
        {
            asset.Unload();
        }
    }
}
