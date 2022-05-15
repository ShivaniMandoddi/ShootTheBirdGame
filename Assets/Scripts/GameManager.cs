using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public GameObject launcher;
    public Text lifeText;
    public Text scorePointsText;
    #endregion
    #region PRIVATE VARIABLES
    private int maxLives = 3;
    private int score;
    private int maxscorePoints=10;
    private int lives;

    #endregion
    #region SINGLETON
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
                if (instance == null)
                {
                    GameObject container = GameObject.Find("GameManager");
                    instance = container.GetComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    #region MONOBEHAVIOUR METHODS
    void Start()
    {
        lives = maxLives;
        lifeText.text = lives.ToString();
        StartCoroutine("SpawningBirds");
        StartCoroutine("SpawningLife");
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
            SpawnBirdorLife(Constants.BIRD_PREFAB_NAME);
        }

    }
    IEnumerator SpawningLife()
    {
        while (true)
        {
            yield return (new WaitForSeconds(Random.Range(4f, 10f)));
            SpawnBirdorLife(Constants.LIFE_PREFAB_NAME);
        }

    }
    #endregion

    #region PUBLIC METHODS
    public void ClickToLaunch()
    {
        GameObject bullet=PoolManager.Instance.Spawn(Constants.BULLET_PREFAB_NAME);
        bullet.transform.position=launcher.transform.position;
    }
    public void SpawnBirdorLife(string prefabName)
    {
        GameObject bird=PoolManager.Instance.Spawn(prefabName);
        Vector2 resolution=new Vector2(Screen.width,Screen.height);
        Vector2 worldPosition=Camera.main.ScreenToWorldPoint(resolution);
        bird.transform.position=new Vector3(worldPosition.x+2.5f,Random.Range(-worldPosition.y,worldPosition.y));
    }
    public void PlayerLiveDecrement()
    {
        lives--;
        lifeText.text = lives.ToString();
    }
    public void PlayerLiveIncrement()
    {
        lives++;
        lifeText.text = lives.ToString();
    }
    public void Score()
    {
        score++;
        scorePointsText.text = score.ToString();
        if(score==maxscorePoints)
        {
            WonGame();
        }
    }
    #endregion

    #region PRIVATE METHODS
    private void WonGame()
    {
        
    }
    #endregion
}
