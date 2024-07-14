using BootStrap.Data.SavesServices;

namespace BootStrap.Data.DataServices
{
    public interface IPersistentProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}