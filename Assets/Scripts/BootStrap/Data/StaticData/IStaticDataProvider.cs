namespace BootStrap.Data.StaticData
{
    public interface IStaticDataProvider
    {
        AssetsReferences AssetsReferences { get; }
        DefaultPlayerSettings DefaultPlayerSettings { get; }
    }
}