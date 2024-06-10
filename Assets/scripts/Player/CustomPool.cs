using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPool<T> where  T : MonoBehaviour
{
    private T _prefab;
    private Stack<T> _pool;

    public CustomPool(T prefab, int count)
    {
        _prefab = prefab;
        _pool = new Stack<T>();
        

        for (int i = 0; i < count; i++)
        {
            var pullObj = GameObject.Instantiate(prefab);
            pullObj.gameObject.SetActive(false);
            _pool.Push(pullObj);
        }

    }


    public T Get()
    {
        T getObj;
        if (_pool.Count == 0)
        {
            getObj = Create();
        }
        else
        {
            getObj = _pool.Pop();
        }
    
        
        getObj.gameObject.SetActive(true);
        return getObj;
    }


    public T Create()
    {
        var createObj = GameObject.Instantiate(_prefab);
        return createObj;
    }


    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Push(obj);
    }
}
