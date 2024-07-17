using System.Collections.Generic;
using UnityEngine;

namespace PopUp.Pool
{
    public abstract class ObjectPool<T> where T : Component
    {
        protected T Prefab;
        
        private Stack<T> inactiveInstances = new Stack<T>();

        public T GetObjectFromPool(Vector2 position, Transform root, Quaternion rotation) 
        {
            T spawnedGameObject;
        
            if (inactiveInstances.Count > 0) 
            {
                spawnedGameObject = inactiveInstances.Pop();
                spawnedGameObject.gameObject.SetActive(true);
            }
            
            spawnedGameObject = Object.Instantiate(Prefab, position, rotation, root);
        
            return spawnedGameObject;
        }
    
        public void ReturnObject(T toReturn) 
        {
            toReturn.gameObject.SetActive(false);
            inactiveInstances.Push(toReturn);
        }
    }
}