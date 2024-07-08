using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace PopUp.Pool
{
    public abstract class ObjectPool<T> where T : Component
    {
        private WaitForSeconds _delay = new WaitForSeconds(1f);
        private Stack<T> inactiveInstances = new Stack<T>();
        private IObjectResolver _resolver;

        protected T _prefab;
    
        [Inject]
        public void Construct(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public T GetObjectFromPool(Vector2 position, Transform root, Quaternion rotation) 
        {
            T spawnedGameObject;
        
            if (inactiveInstances.Count > 0) 
            {
                spawnedGameObject = inactiveInstances.Pop();
            }
            else
            {
                spawnedGameObject = Object.Instantiate(_prefab, position, rotation, root);
            }
        
            return spawnedGameObject;
        }
    
        public void ReturnObject(T toReturn) 
        {
            toReturn.gameObject.SetActive(false);
            inactiveInstances.Push(toReturn);
        }
    }
}