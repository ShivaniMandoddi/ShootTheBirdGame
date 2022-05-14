using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserInput
{
    public class UserInputHandler : MonoBehaviour
    {

        #region Events
        public delegate void TapAction(Touch touch);
        public static event TapAction OnTouchAction;
        #endregion
        #region PUBLIC VARIABLES

        #endregion
        #region PRIVATE VARIABLES
        private Vector2 movement;
        float tapMaxMovement = 50f;
        private bool tapGestureFailed = false;
        #endregion
        #region MONOBEHAVIOUR METHODS
        void Start()
        {

        }


        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];  // Need to find out no. of touches on the screen. If there are more no. of touches, need to call array
                if (touch.phase == TouchPhase.Began) // We have several touch phases, began enters the first frame of the touch
                {
                    movement = Vector2.zero; //We made our movement to zero
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    movement += touch.deltaPosition; // The position delta since last change in pixel coordinates.
                    if (movement.magnitude > tapMaxMovement)
                    {
                        tapGestureFailed = true;
                        Debug.Log("Touch Failed");
                    }
                }
                else
                {
                    if (!tapGestureFailed) // If finger is removed, then we are calling tap 
                    {
                        if (OnTouchAction != null)
                        {
                            OnTouchAction(touch);
                        }

                    }
                    tapGestureFailed = false; // ready for the next tap

                }

            }
        }
        #endregion
        #region PUBLIC METHODS
       
        #endregion
        #region PRIVATE METHODS

        #endregion

    }
}
