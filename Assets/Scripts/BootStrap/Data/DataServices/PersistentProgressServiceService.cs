using BootStrap.Data.SavesServices;

namespace BootStrap.Data.DataServices
{
    public class PersistentProgressServiceService: IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}