using UnityEngine;
using System.Collections;

public class StickAim : MonoBehaviour {

    #region Public Properties

    public bool isPlayerOne = true;
    public float deadZone = 0.1f;
    public float maximumRange = 3.0f;

    #endregion

    #region Private Properties
    
    Vector3 originalPosition;
    
    #endregion
    
    #region Unity Methods
    
    void Awake () {
        originalPosition = transform.localPosition;
    }
    
    void Update () {
        string playerNumber = isPlayerOne ? "One" : "Two";
        string joystickHorizontalName = "HorizontalPlayer" + playerNumber;
        string joystickVerticalName = "VerticalPlayer" + playerNumber;

        float horizontalInput = Input.GetAxis (joystickHorizontalName);
        float verticalInput = -Input.GetAxis (joystickVerticalName);

        Vector3 handPosition = originalPosition;

        if (!(horizontalInput < deadZone && horizontalInput > -deadZone)) {
            handPosition.x = horizontalInput * maximumRange;
        }
        if (!(verticalInput < deadZone && verticalInput > -deadZone)) {
            handPosition.y = verticalInput * maximumRange;
        }

        transform.localPosition = handPosition;
    }
    
    #endregion
}
