using UnityEngine;

namespace BootStrap.Data.StaticData
{
    [CreateAssetMenu(fileName = "AllData", menuName = "ScriptableObject/AllData")]
    public class AllData: ScriptableObject
    {
        public DefaultPlayerSettings DefaultPlayerSettings;
        public AssetsReferences AssetsReferences;
    }
}