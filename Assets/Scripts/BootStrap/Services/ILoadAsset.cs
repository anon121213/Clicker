using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BootStrap.Services
{
    public interface ILoadAsset
    {
        TObject GetAsset<TObject>(string name) where TObject : Object;
        UniTask LoadAsset(string path);
    }
}