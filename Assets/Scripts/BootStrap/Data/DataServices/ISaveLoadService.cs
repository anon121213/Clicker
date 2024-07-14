using BootStrap.Data.SavesServices;

namespace BootStrap.Data.DataServices
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}