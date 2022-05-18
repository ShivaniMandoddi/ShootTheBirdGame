using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region PUBLIC VARIABLES

    #endregion
    #region PRIVATE VARIABLES
    private Vector3 playerTouchPosition;
    private const string PLAYER_MOVEMENT_COROUTINE = "Player_Move_UpAndDown";
    Rigidbody2D rigidbody2D;
    #endregion
    #region MONOBEHAVIOUR METHODS
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // Acessing the rigidbody component of player
    }
    private void OnEnable()
    {
        UserInput.UserInputHandler.OnTouchAction += ChangeCoordinates;     //When the gameobject is active, subscribing the event
    }
    private void OnDisable()
    {

        UserInput.UserInputHandler.OnTouchAction -= ChangeCoordinates; // When the gameobject is inactive, desubscribing event
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==Constants.LIFE_LAYER_NUMBER) // When the player collides with life, we increase the life
        {
            PoolManager.Instance.Recycle(Constants.LIFE_PREFAB_NAME, collision.gameObject); // Setting life prefab back to pool
            GameManager.Instance.PlayerLiveIncrement();
        }
    }
   
    #endregion
    #region PUBLIC METHODS
    public void ChangeCoordinates(Touch touch)
    {
        playerTouchPosition = Camera.main.ScreenToWorldPoint(touch.position); //Changing the pixelcoordinate to world coordinates
        StopCoroutine(PLAYER_MOVEMENT_COROUTINE); 
        StartCoroutine(PLAYER_MOVEMENT_COROUTINE); // Starting the player movement coroutine function

    }
    #endregion
    #region PRIVATE METHODS
    private IEnumerator Player_Move_UpAndDown()
    {
        
        playerTouchPosition.z = this.transform.position.z; //Assigning z value of current position to touch position
        playerTouchPosition.x=this.transform.position.x;//Assigning x value of current position to touch position

        float distance = Vector3.Distance(transform.position, playerTouchPosition); //Calculating distance between player current position and touch position
        for (float i = 0; i < distance; i+=Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, playerTouchPosition, i); // Transforming from current position slowly to the touch position 
            yield return null;
        }
        transform.position = playerTouchPosition; 
        
        
    }
    #endregion
}
