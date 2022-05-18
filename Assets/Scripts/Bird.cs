using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public GameObject sparkEffect; 
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
        transform.Translate(Vector3.left * 3f * Time.deltaTime);      // Giving bird movement in the left direction
        if(transform.position.x<-12.5f)                   // When bird is out of the screen, then returning bird back to pool
            PoolManager.Instance.Recycle(Constants.BIRD_PREFAB_NAME, this.gameObject);
    }
    private void OnBecameInvisible()
    {
        PoolManager.Instance.Recycle("Bird", this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==Constants.BULLET_LAYER_NUMBER) // collision between bird and bullet
        {
            Destroy(Instantiate(sparkEffect, collision.gameObject.transform.position, Quaternion.identity), 2f);
            PoolManager.Instance.Recycle(Constants.BULLET_PREFAB_NAME,collision.gameObject);
            PoolManager.Instance.Recycle(Constants.BIRD_PREFAB_NAME, this.gameObject);
            GameManager.Instance.Score(); //Increasing the player score
        }
        if(collision.gameObject.name==Constants.PLAYER_PREFAB_NAME) // collision between player and bird
        {
            PoolManager.Instance.Recycle(Constants.BIRD_PREFAB_NAME, this.gameObject);
           
            GameManager.Instance.PlayerLiveDecrement(collision.gameObject); // Decreasing the player life
        }
    }
    #endregion

    #region PUBLIC METHODS

    #endregion
    #region PRIVATE METHODS

    #endregion
}
