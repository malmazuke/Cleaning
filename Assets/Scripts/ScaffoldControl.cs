using UnityEngine;
using System.Collections;

public class ScaffoldControl : MonoBehaviour {

    #region Public Properties
    
    public float maximumForce = 200.0f;
    
    #endregion
    
    #region Private Properties
    
    Rigidbody rb;
    
    #endregion
    
    void Awake () {
        rb = GetComponent<Rigidbody> ();
    }
    
    // Update is called once per frame
    void Update () {
        var inputForce1 = Input.GetAxis ("HorizontalPlayerOne");
        rb.AddForce (transform.right * maximumForce * inputForce1);
        var inputForce2 = Input.GetAxis ("HorizontalPlayerTwo");
        rb.AddForce (transform.right * maximumForce * inputForce2);
    }
}
