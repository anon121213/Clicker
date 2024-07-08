using Data;

namespace BootStrap.Services
{
    public interface IPersistentProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}