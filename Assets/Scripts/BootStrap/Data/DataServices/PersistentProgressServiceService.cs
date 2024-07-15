using BootStrap.Data.StaticData;

namespace BootStrap.Data.DataServices
{
    public class PersistentProgressServiceService: IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}