using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rope : MonoBehaviour {

	#region Public Properties

	public Transform ropeBottom;
	public GameObject ropePrefab;
	public float ropeLength = 5.0f;

	#endregion

	#region Private Properties

	LinkedList<GameObject> ropeSegments = new LinkedList<GameObject>();
	Rigidbody rb;
	float segmentLength;

	#endregion

	#region Unity Methods

	void Awake () {
		rb = GetComponent<Rigidbody> ();
		segmentLength = ropePrefab.GetComponent<Renderer> ().bounds.size.y;
	}

	// Use this for initialization
	void Start () {
		CreateRope ();
	}
	
	// Update is called once per frame
	void Update () {
		float currentLength = ropeSegments.Count * segmentLength;
		if (currentLength + segmentLength < ropeLength) {
			AddSegment ();
		} else if (currentLength - segmentLength > ropeLength) {
			RemoveSegment ();
		}
	}

	#endregion

	#region Private Methods

	void CreateRope () {
		int numberOfSegments = (int)(ropeLength/segmentLength);

		for (int i = 0; i < numberOfSegments; i++) {
			AddSegment ();
		}
	}

	void AddSegment () {
		Rigidbody previousRigidbody;
		if (ropeSegments.Count == 0) {
			previousRigidbody = rb;
		} else {
			previousRigidbody = ropeSegments.Last.Value.GetComponent<Rigidbody> ();
		}

		Vector3 nextPosition = previousRigidbody.position;
		nextPosition.y -= segmentLength;

		GameObject segment = Instantiate (ropePrefab, transform) as GameObject;
		segment.transform.position = nextPosition;
		segment.GetComponent<ConfigurableJoint>().connectedBody = previousRigidbody;

		ropeSegments.AddLast (segment);
	}

	void RemoveSegment () {
		GameObject last = ropeSegments.Last.Value;
		if (last == null) {
			return;
		}
		Destroy (last);
		ropeSegments.RemoveLast();
	}

	#endregion
}
