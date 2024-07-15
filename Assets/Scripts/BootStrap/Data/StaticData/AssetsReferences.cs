using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BootStrap.Data.StaticData
{
    
    [CreateAssetMenu(fileName = "AssetsReferences", menuName = "ScriptableObject/AssetsReferences")]
    public class AssetsReferences: ScriptableObject
    {
        public AssetReference MainScene;
        
        [Space]
        public AssetReference Hud;
        public AssetReference ClickSystem;
        public AssetReference UpgradeSystem;
        public AssetReference LevelSystem;
        public AssetReference PopUp;
    }
}