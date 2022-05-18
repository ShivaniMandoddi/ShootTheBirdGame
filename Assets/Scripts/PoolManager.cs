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
    private Dictionary<string, ObjectPool> poolDictionary; //Creating a dictionary to make a separate pool for separate prefab
    #endregion
    #region SINGLETON     //Creating singleton class
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
            AddToDictionary(pool[i].obj, pool[i].capacity); //Sending prefab and capacity to add into poolDictionary
        }
    }
    void Update()
    {
       
    }
    #endregion
    #region PUBLIC METHODS
    public void AddToDictionary(GameObject obj,int initialCapacity)
    {
        if (poolDictionary == null)      //Intially when dictionary is null, then we need to create object out of it;
            poolDictionary = new Dictionary<string, ObjectPool>();
        ObjectPool objectPool = new ObjectPool(obj, initialCapacity); //Creating new pool to the prefab
        poolDictionary.Add(obj.name, objectPool); //Adding prefab name and pool to the dictionary 
    }
    public GameObject Spawn(string prefabName)
    {
        if (poolDictionary.ContainsKey(prefabName)) //Checking whether the dictionary contains the given prefab name or not
            return (poolDictionary[prefabName].Spawn()); // If it is, then we call for that particular pool to spawn the gameobject
        return null;
    }
    public GameObject Recycle(string prefabName,GameObject obj)
    {
        
        if (poolDictionary.ContainsKey(prefabName)) //Checking whether the dictionary contains the given prefab name or not
            return (poolDictionary[prefabName].BackToPool(obj));// If it is, then we return the gameobject to particular pool 
        return null;
    }
    #endregion
    #region PRIVATE METHODS

    #endregion
}
