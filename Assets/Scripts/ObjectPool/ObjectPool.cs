using System;
using System.Collections.Generic;

public class ObjectPool<T>
{
    private Queue<T> objectPool = new Queue<T>();
    private Func<T> factoryFunc;

    public ObjectPool(Func<T> factoryFunc, int initialSize)
    {
        this.factoryFunc = factoryFunc;

        Warm(initialSize);
    }

    public void Warm(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            T obj = factoryFunc();
            objectPool.Enqueue(obj);
        }
    }

    public T Get()
    {
        if (objectPool.Count > 0)
        {
            return objectPool.Dequeue();
        }
        else
        {
            T newObject = factoryFunc();
            return newObject;
        }
    }

    public void Return(T objectToReturn)
    {
        objectPool.Enqueue(objectToReturn);
    }
}
