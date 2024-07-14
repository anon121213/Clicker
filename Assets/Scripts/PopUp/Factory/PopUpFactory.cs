using System.Threading.Tasks;
using PopUp.Main;
using PopUp.Pool;
using UnityEngine;
using VContainer;

namespace PopUp.Factory
{
    public class PopUpFactory: IPopUpFactory
    {
        private PopUpPool _pool;
        private IObjectResolver _objectResolver;
        
        public PopUpFactory(PopUpPool pool, IObjectResolver objectResolver)
        {
            _pool = pool;
            _objectResolver = objectResolver;
        }
        
        public async Task<PopUpCountChanger> Create(Vector2 position, Transform root, Quaternion rotation)
        {
            await _pool.Warmup();
        
            PopUpCountChanger gameObject = _pool.GetObjectFromPool(position, root, rotation);
            _objectResolver.Inject(gameObject);
        
            gameObject.OnDisabled += ReturnToPool;
            return gameObject;
        }

        private void ReturnToPool(PopUpCountChanger gameObject)
        {
            gameObject.OnDisabled -= ReturnToPool;
            _pool.ReturnObject(gameObject);
        }
    }
}