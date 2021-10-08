namespace VanguardProtocol.Core.AssetPipeline;

/// <summary>
/// Thin asset registry. MonoGame ContentManager stays in the host; this layer tracks logical ids
/// and leaves room for hot-reload in development builds.
/// </summary>
public sealed class AssetRegistry
{
    private readonly Dictionary<string, object> _assets = new(StringComparer.OrdinalIgnoreCase);

    public void Set<T>(string id, T asset) where T : class
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        ArgumentNullException.ThrowIfNull(asset);
        _assets[id] = asset;
    }

    public T Get<T>(string id) where T : class
    {
        if (!_assets.TryGetValue(id, out var asset) || asset is not T typed)
            throw new KeyNotFoundException($"Asset '{id}' of type {typeof(T).Name} was not found.");
        return typed;
    }

    public bool TryGet<T>(string id, out T? asset) where T : class
    {
        if (_assets.TryGetValue(id, out var value) && value is T typed)
        {
            asset = typed;
            return true;
        }

        asset = null;
        return false;
    }

    public bool Remove(string id) => _assets.Remove(id);

    public void Clear() => _assets.Clear();
}
