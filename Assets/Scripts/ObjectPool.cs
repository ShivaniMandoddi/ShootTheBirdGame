using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool 
{
    private List<GameObject> poolitem=new List<GameObject>();
    private GameObject prefab;
    public ObjectPool(GameObject _prefab,int capacity)
    {
        prefab = _prefab;
        for (int i = 0; i < capacity; i++)
        {
           
            
            GameObject temp=GameObject.Instantiate(prefab) as GameObject;
            temp.SetActive(false);
           poolitem.Add(temp);
            
        }
    }
    public GameObject Spawn()
    {
        foreach (GameObject item in poolitem)
        {
            if(item.activeInHierarchy==false)
            {
                item.SetActive(true);
                return item;
            }
        }
        return null;

    }
    public GameObject BackToPool(GameObject obj)
    {
        
        obj.SetActive(false);
        return obj;
    }
}
