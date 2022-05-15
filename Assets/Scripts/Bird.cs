using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
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

        }
    }
    #endregion

    #region PUBLIC METHODS

    #endregion
    #region PRIVATE METHODS

    #endregion
}
