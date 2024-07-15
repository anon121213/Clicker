using BootStrap.Data.StaticData;

namespace BootStrap.Data.DataServices
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}