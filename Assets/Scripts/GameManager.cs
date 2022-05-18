using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        lifeText.text = lives.ToString(); // Displaying the number of lives
        StartCoroutine("SpawningBirds"); // Starting the bird spawning
        StartCoroutine("SpawningLife"); // Starting the life spawning
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
            yield return (new WaitForSeconds(Random.Range(2f, 4f)));   // For every 2 to 4 seconds we clone the bird
            SpawnBirdorLife(Constants.BIRD_PREFAB_NAME);
        }

    }
    IEnumerator SpawningLife()
    {
        while (true)
        {
            yield return (new WaitForSeconds(Random.Range(7f, 12f))); // For every 7 to 8 seconds we clone the bird
            SpawnBirdorLife(Constants.LIFE_PREFAB_NAME);
        }

    }
    #endregion

    #region PUBLIC METHODS
    public void ClickToLaunch() // TO launch the bullet 
    {
        GameObject bullet=PoolManager.Instance.Spawn(Constants.BULLET_PREFAB_NAME); 
        bullet.transform.position=launcher.transform.position; //Setting the launcher position as bullet position
    }
    public void SpawnBirdorLife(string prefabName) // Spawnign bird or life
    {
        GameObject temp=PoolManager.Instance.Spawn(prefabName);
        Vector2 resolution=new Vector2(Screen.width,Screen.height);
        Vector2 worldPosition=Camera.main.ScreenToWorldPoint(resolution); // changing the resloution to world coordinates
        temp.transform.position=new Vector3(worldPosition.x+2.5f,Random.Range(-worldPosition.y,worldPosition.y)); // Randomly setting a position to game object
    }
    public void PlayerLiveDecrement(GameObject player)
    {
        lives--;                   // Decreasing the lives
        player.SetActive(false);   // Making player to set inactive
        StartCoroutine("PlayerInvisible",player); 
        lifeText.text = lives.ToString();  // Displaying the life of player
        if(lives==0) // if player life gets zero 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloading the game scene again
        }
    }
    public void PlayerLiveIncrement() 
    {
        lives++; // Increasing the lives of player
        lifeText.text = lives.ToString();
    }
    public void Score()
    {
        score++;  // Increasing the score of plyer
        scorePointsText.text = score.ToString();
        if(score==maxscorePoints)
        {
            WonGame();
        }
    }
    #endregion

    #region PRIVATE METHODS
    IEnumerator PlayerInvisible(GameObject player)
    {
        yield return (new WaitForSeconds(1f)); // Waiting for 1 second and again making player to active
        player.SetActive(true);

    }
    private void WonGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // When player won the game, making scene to 
    }
    #endregion
}
