public interface IDataSaver
{
    PlayerData Load();
    void Save(PlayerData playerData);
}