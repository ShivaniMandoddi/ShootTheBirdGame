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
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        UserInput.UserInputHandler.OnTouchAction += ChangeCoordinates;
    }
    private void OnDisable()
    {

        UserInput.UserInputHandler.OnTouchAction -= ChangeCoordinates;
    }
    #endregion
    #region PUBLIC METHODS
    public void ChangeCoordinates(Touch touch)
    {
        playerTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        StopCoroutine(PLAYER_MOVEMENT_COROUTINE);
        StartCoroutine(PLAYER_MOVEMENT_COROUTINE);

    }
    #endregion
    #region PRIVATE METHODS
    private IEnumerator Player_Move_UpAndDown()
    {
        
        playerTouchPosition.z = this.transform.position.z; //Assigning z value of current position to touch position
        playerTouchPosition.x=this.transform.position.x;//Assigning x value of current position to touch position

        float distance = Vector3.Distance(transform.position, playerTouchPosition);
        for (float i = 0; i < distance; i+=Time.deltaTime)
        {
            transform.position = Vector3.Lerp(transform.position, playerTouchPosition, i); // Transforming the current position slowly to the touch position 
            yield return null;
        }
        transform.position = playerTouchPosition;
        
        
    }
    #endregion
}
