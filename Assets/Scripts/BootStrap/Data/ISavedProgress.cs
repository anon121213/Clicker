namespace BootStrap.Data
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgres progres);
    }

    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgres progres);
    }
}