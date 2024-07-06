using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using VContainer;

public abstract class ClickPopUpPool<T> where T : Component
{
    public abstract T Create();
    
    
    private WaitForSeconds _delay = new WaitForSeconds(1f);
    private Stack<T> inactiveInstances = new Stack<T>();

    private IObjectResolver _resolver;

    [Inject]
    public void Construct(IObjectResolver resolver)
    {
        _resolver = resolver;
    }
    
    private T GetObjectFromPool() 
    {
        T spawnedGameObject;
        
        if (inactiveInstances.Count > 0) 
        {
            spawnedGameObject = inactiveInstances.Pop();
        }
        else
        {
            spawnedGameObject = Create();
        }
        
        spawnedGameObject.GetComponent<PopUpCountChanger>().ChangeCount();
        spawnedGameObject.gameObject.SetActive(true);
        
        var textMeshPro = spawnedGameObject.GetComponent<TextMeshProUGUI>();
        var color = textMeshPro.color;
        color.a = 1;
        textMeshPro.color = color;
        
        //StartCoroutine(Deactivate(spawnedGameObject.gameObject));
        
        return spawnedGameObject;
    }
    
    private void ReturnObject(T toReturn) 
    {
        var textMeshPro = toReturn.GetComponent<TextMeshProUGUI>();
        var color = textMeshPro.color;
        color.a = 1;
        textMeshPro.color = color;
        toReturn.transform.localPosition = Vector3.zero;
        

        toReturn.gameObject.SetActive(false);
        inactiveInstances.Push(toReturn);
    }
    
    public IEnumerator Deactivate(T gameObject)
    {
        yield return _delay;
        ReturnObject(gameObject);
    }
}