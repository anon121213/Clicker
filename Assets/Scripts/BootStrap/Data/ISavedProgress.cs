namespace BootStrap.Data
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgres progress);
    }

    public interface ISavedProgress : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgres progres);
    }
}