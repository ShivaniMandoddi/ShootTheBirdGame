using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public GameObject launcher;
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

    }
    #endregion

    #region PUBLIC METHODS
    public void ClickToLaunch()
    {
        GameObject bullet=PoolManager.Instance.Spawn("Bullet");
        bullet.transform.position=launcher.transform.position;
    }
    #endregion

    #region PRIVATE METHODS

    #endregion
}
