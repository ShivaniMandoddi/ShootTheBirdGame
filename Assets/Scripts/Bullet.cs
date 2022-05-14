using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region PUBLIC VARIABLES
    
    #endregion
    #region PRIVATE VARIABLES

    #endregion
    #region MONOBEHAVIOUR METHODS
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( Vector3.right * 4f * Time.deltaTime);
        if(transform.position.x>12)
        {
            Debug.Log("I am invisible");
            PoolManager.Instance.Recycle("Bullet", this.gameObject);
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
