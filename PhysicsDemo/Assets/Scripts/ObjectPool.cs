using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<MonoBehaviour> pool = new Queue<MonoBehaviour>();

    protected MonoBehaviour TakeObject()
    {
        if(pool.Count == 0)
        {
            return null;
        }
        MonoBehaviour outObject = pool.Dequeue();
        outObject.gameObject.SetActive(true);
        return outObject;
    }
    protected void ReturnObject(MonoBehaviour obj)
    {
        if (obj != null && !pool.Contains(obj))
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    protected void InitializePool(MonoBehaviour obj, int size)
    {
        for(int i = 0; i < size; i++)
        {
            ReturnObject(Instantiate(obj));
        }
    }
    public int AvailableObjectCount()
    {
        return pool.Count;
    }
}
