using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region PUBLIC VARIABLES
    
    #endregion
    #region PRIVATE VARIABLES
    private float bulletSpeed=6f;
    #endregion
    #region MONOBEHAVIOUR METHODS
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( Vector3.right * bulletSpeed * Time.deltaTime);      // Transforming the bullet in right direction with speed 
        if(transform.position.x>12)         // When the bullet is out of screen, then we send back to pool
        {
            
            PoolManager.Instance.Recycle(Constants.BULLET_PREFAB_NAME, this.gameObject);
        }
        
    }
    private void OnEnable()
    {
      
    }
    
   /* public void OnBecameInvisible()
    {
        Debug.Log("I am invisible");
        PoolManager.Instance.Recycle("Bullet", this.gameObject);
    }*/

    #endregion
    #region PUBLIC METHODS

    #endregion
    #region PRIVATE METHODS

    #endregion

}
