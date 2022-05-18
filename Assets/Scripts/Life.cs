using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 3f * Time.deltaTime); //Movement of life object
        if(transform.position.x<-12.5f)
        {
            PoolManager.Instance.Recycle(Constants.LIFE_PREFAB_NAME,this.gameObject); // When object is out of screen, then returning back to pool
        }
    }
   
}
