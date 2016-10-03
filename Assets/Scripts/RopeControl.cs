using UnityEngine;
using System.Collections;

public class RopeControl : MonoBehaviour {

    public Rope leftRope;
    public Rope rightRope;
    
    // Update is called once per frame
    void Update () {
        if (Input.GetAxis ("LeftRopeUp") > 0.0f) {
            leftRope.DecreaseRopeLength ();
        } else if (Input.GetButton ("LeftRopeDown")) {
            leftRope.IncreaseRopeLength ();
        }
        
        if (Input.GetAxis ("RightRopeUp") > 0.0f) {
            rightRope.DecreaseRopeLength ();
        } else if (Input.GetButton ("RightRopeDown")) {
            rightRope.IncreaseRopeLength ();
        }
    }
}
