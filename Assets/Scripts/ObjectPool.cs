using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool 
{
    private List<GameObject> poolitem=new List<GameObject>(); //Creating List to store initially cloned objects
    private GameObject prefab; 
    public ObjectPool(GameObject _prefab,int capacity) //Constructor with prefab and capacity to pool the prefab as arguments
    {
        prefab = _prefab;
        for (int i = 0; i < capacity; i++)
        {
           
            
            GameObject temp=GameObject.Instantiate(prefab) as GameObject; //Instantiating the prefab
            temp.SetActive(false);            //Setting gameobject as inactive
           poolitem.Add(temp);  //Adding the instantiated gameobject to pool
            
        }
    }
    public GameObject Spawn() // Spawn is to get the gameobject from pool
    {
        foreach (GameObject item in poolitem)       
        {
            if(item.activeInHierarchy==false) // If gameobject is inactive, then we set it as active and returning that gameobject
            {
                item.SetActive(true);
                return item;
            }
        }
        return null;

    }
    public GameObject BackToPool(GameObject obj)   // Getting back gameobject to pool 
    {
        
        obj.SetActive(false);
        return obj;
    }
}
