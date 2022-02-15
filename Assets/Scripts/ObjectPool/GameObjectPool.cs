using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    public int initialSize = 10;
    private ObjectPool<GameObject> pool;

    public void Awake()
    {
        Debug.Log("POOL AWAKE 1");
        pool = new ObjectPool<GameObject>(() =>
        {
            GameObject newObject = Instantiate(objectPrefab);
            newObject.SetActive(false); // SetActive(false) is automatically called so we don't have to call it in Warm()
            newObject.transform.SetParent(transform);

            return newObject;
        }, initialSize);
    }

    public void Warm(int amount)
    {
        pool.Warm(amount);
    }

    public GameObject Get()
    {
        GameObject get = pool.Get();
        get.gameObject.SetActive(true);
        
        return get;
    }

    //Note: 
    // This takes the gameObject instance, and NOT the prefab instance.
    // Without this call the object will never be available for re-use!
    // gameObject.SetActive(false) is automatically called
    public void Return(GameObject toReturn)
    {
        toReturn.SetActive(false);
        toReturn.transform.SetParent(null);
        pool.Return(toReturn);
    }
}
