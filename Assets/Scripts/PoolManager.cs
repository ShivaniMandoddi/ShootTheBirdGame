using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectToPool
{
    public GameObject obj;
    public int capacity;
}
public class PoolManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public ObjectToPool[] pool;
    #endregion
    #region PRIVATE VARIABLES
    private Dictionary<string, ObjectPool> poolDictionary;
    #endregion
    #region SINGLETON
    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PoolManager();
                if (instance == null)
                {
                    GameObject container = GameObject.Find("PoolManager");
                    instance = container.GetComponent<PoolManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    #region MONOBEHAVIOUR METHODS
    
    void Start()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            AddToDictionary(pool[i].obj, pool[i].capacity);
        }
    }
    void Update()
    {
       
    }
    #endregion
    #region PUBLIC METHODS
    public void AddToDictionary(GameObject obj,int initialCapacity)
    {
        if (poolDictionary == null)
            poolDictionary = new Dictionary<string, ObjectPool>();
        ObjectPool objectPool = new ObjectPool(obj, initialCapacity);
        poolDictionary.Add(obj.name, objectPool);
    }
    public GameObject Spawn(string prefabName)
    {
        if (poolDictionary.ContainsKey(prefabName))
            return (poolDictionary[prefabName].Spawn());
        return null;
    }
    public GameObject Recycle(string prefabName,GameObject obj)
    {
        
        if (poolDictionary.ContainsKey(prefabName))
            return (poolDictionary[prefabName].BackToPool(obj));
        return null;
    }
    #endregion
    #region PRIVATE METHODS

    #endregion
}
