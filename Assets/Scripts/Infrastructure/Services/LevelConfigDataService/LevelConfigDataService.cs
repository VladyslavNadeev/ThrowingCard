using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.LevelConfigDataService
{
    public class LevelConfigDataService : MonoBehaviour, ILevelConfigDataService
    {
        private const string LevelStaticDataPath = "ConfigData/TutorialLevelConfig";
        
        private Dictionary<string, LevelConfigData> _levelDatas;

        public void LoadLevel()
        {
            _levelDatas = Resources
                .LoadAll<LevelConfigData>(LevelStaticDataPath)
                .ToDictionary(x => x.SceneName, x => x);
        }
        
        public LevelConfigData GetLevelDataFor(string scene) =>
            _levelDatas[scene];
    }
}