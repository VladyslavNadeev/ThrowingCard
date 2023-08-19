namespace Assets.Scripts.Infrastructure.LevelConfigDataService
{
    public interface ILevelConfigDataService
    {
        void LoadLevel();
        LevelConfigData GetLevelDataFor(string scene);
    }
}