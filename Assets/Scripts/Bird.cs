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
        transform.Translate(Vector3.left * 3f * Time.deltaTime);
        if(transform.position.x<-12.5f)
            PoolManager.Instance.Recycle(Constants.BIRD_PREFAB_NAME, this.gameObject);
    }
    private void OnBecameInvisible()
    {
        PoolManager.Instance.Recycle("Bird", this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==Constants.BULLET_LAYER_NUMBER)
        {
            Destroy(Instantiate(sparkEffect, collision.gameObject.transform.position, Quaternion.identity), 2f);
            PoolManager.Instance.Recycle(Constants.BULLET_PREFAB_NAME,collision.gameObject);
            PoolManager.Instance.Recycle(Constants.BIRD_PREFAB_NAME, this.gameObject);
            GameManager.Instance.Score();
        }
        if(collision.gameObject.name==Constants.PLAYER_PREFAB_NAME)
        {
            PoolManager.Instance.Recycle(Constants.BIRD_PREFAB_NAME, this.gameObject);
            GameManager.Instance.PlayerLiveDecrement();
        }
    }
    #endregion

    #region PUBLIC METHODS

    #endregion
    #region PRIVATE METHODS

    #endregion
}
