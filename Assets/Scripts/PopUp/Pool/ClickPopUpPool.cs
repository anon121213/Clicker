using System.Collections.Generic;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using VContainer;
using VContainer.Unity;

public class ClickPopUpPool: MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _popUpPerent;
    
    private WaitForSeconds _delay = new WaitForSeconds(1f);
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    private IObjectResolver _resolver;

    [Inject]
    public void Construct(IObjectResolver resolver)
    {
        _resolver = resolver;
    }
    
    public GameObject GetObject(Vector2 position) 
    {
        GameObject spawnedGameObject;
        
        if (inactiveInstances.Count > 0) 
        {
            spawnedGameObject = inactiveInstances.Pop();
        }
        else 
        {
            spawnedGameObject = _resolver.Instantiate(_prefab, position, quaternion.identity, _popUpPerent);
            spawnedGameObject.GetComponent<PopUpCountChanger>().ChangeCount();
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        spawnedGameObject.transform.position = position;
        spawnedGameObject.GetComponent<PopUpCountChanger>().ChangeCount();
        spawnedGameObject.SetActive(true);
        
        StartCoroutine(Deactivate(spawnedGameObject));
        
        return spawnedGameObject;
    }
    
    public void ReturnObject(GameObject toReturn) 
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();
        var textMeshPro = pooledObject.GetComponent<TextMeshProUGUI>();
        var color = textMeshPro.color;
        color.a = 1;
        textMeshPro.color = color;
        toReturn.transform.localPosition = Vector3.zero;
        
        if(pooledObject != null && pooledObject.pool == this)
        {
            toReturn.SetActive(false);
            inactiveInstances.Push(toReturn);
        }
        else
        {
            GameObject.Destroy(toReturn);
            Debug.LogError("This object is not from this pool, he has been destroyed");
        }
    }
    
    private IEnumerator Deactivate(GameObject gameObject)
    {
        yield return _delay;
        ReturnObject(gameObject);
    }
}