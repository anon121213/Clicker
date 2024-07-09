using Data;

namespace BootStrap.Services
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgres LoadProgress();
    }
}