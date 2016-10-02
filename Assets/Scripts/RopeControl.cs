using UnityEngine;
using System.Collections;

public class RopeControl : MonoBehaviour {

	public Rope leftRope;
	public Rope rightRope;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("LeftRopeUp")) {
			leftRope.DecreaseRopeLength ();
		} else if (Input.GetButton ("LeftRopeDown")) {
			leftRope.IncreaseRopeLength ();
		}

		if (Input.GetButton ("RightRopeUp")) {
			rightRope.DecreaseRopeLength ();
		} else if (Input.GetButton ("RightRopeDown")) {
			rightRope.IncreaseRopeLength ();
		}
	}
}
