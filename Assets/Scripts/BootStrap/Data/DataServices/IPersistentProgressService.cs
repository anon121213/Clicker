using BootStrap.Data.StaticData;

namespace BootStrap.Data.DataServices
{
    public interface IPersistentProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}