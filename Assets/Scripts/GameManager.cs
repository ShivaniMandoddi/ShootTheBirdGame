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
        StartCoroutine("SpawningBirds");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region COROUTINE FUNCTIONS
    IEnumerator SpawningBirds()
    {
        while(true)
        {
            yield return (new WaitForSeconds(Random.Range(2f, 6f)));
            SpawnBirds();
        }

    }
    #endregion

    #region PUBLIC METHODS
    public void ClickToLaunch()
    {
        GameObject bullet=PoolManager.Instance.Spawn(Constants.BULLET_PREFAB_NAME);
        bullet.transform.position=launcher.transform.position;
    }
    public void SpawnBirds()
    {
        GameObject bird=PoolManager.Instance.Spawn(Constants.BIRD_PREFAB_NAME);
        Vector2 resolution=new Vector2(Screen.width,Screen.height);
        Vector2 worldPosition=Camera.main.ScreenToWorldPoint(resolution);
        bird.transform.position=new Vector3(worldPosition.x+2.5f,Random.Range(-worldPosition.y,worldPosition.y));
    }
    #endregion

    #region PRIVATE METHODS

    #endregion
}
