using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rope : MonoBehaviour {
    
    #region Public Properties
    
    public Transform ropeTop;
    public GameObject ropePrefab;
    public float ropeChangeSpeed = 3.0f;
    
    #endregion
    
    #region Private Properties
       
    LinkedList<GameObject> ropeSegments = new LinkedList<GameObject>();
    Rigidbody rb;
    float ropeLength;
    float segmentLength;
    
    #endregion
    
    #region Unity Methods
    
    void Awake () {
        rb = GetComponent<Rigidbody> ();
        segmentLength = ropePrefab.GetComponent<Renderer> ().bounds.size.y;
    }
    
    void Start () {
        CreateRope ();
    }
    
    void Update () {
        float currentLength = ropeSegments.Count * segmentLength;
        if (currentLength + segmentLength < ropeLength) {
            AddSegment ();
        } else if (currentLength - segmentLength > ropeLength) {
            RemoveSegment ();
        }
    }
    
    #endregion
    
    #region Public Methods
    
    public void IncreaseRopeLength () {
        ropeLength += ropeChangeSpeed * Time.deltaTime;
    }
    
    public void DecreaseRopeLength () {
        ropeLength -= ropeChangeSpeed * Time.deltaTime;
    }
    
    #endregion
    
    #region Private Methods
    
    void CreateRope () {
        ropeLength = Vector3.Distance (ropeTop.position, transform.position);
        int numberOfSegments = (int)(ropeLength/segmentLength);
        
        for (int i = 0; i < numberOfSegments; i++) {
            AddSegment ();
        }
        JoinLastSegment ();
    }
    
    void AddSegment () {
        Rigidbody previousRigidbody;
        if (ropeSegments.Count == 0) {
            previousRigidbody = rb;
        } else {
            previousRigidbody = ropeSegments.Last.Value.GetComponent<Rigidbody> ();
        }
        
        Vector3 nextPosition = previousRigidbody.position;
        nextPosition.y += segmentLength;
        
        GameObject segment = Instantiate (ropePrefab, transform) as GameObject;
        segment.transform.position = nextPosition;
        segment.GetComponent<ConfigurableJoint>().connectedBody = previousRigidbody;
        
        ropeSegments.AddLast (segment);
        JoinLastSegment ();
    }
    
    void RemoveSegment () {
        LinkedListNode<GameObject> last = ropeSegments.Last;
        if (last == null) {
            return;
        }
        
        GameObject lastSegment = last.Value;
        Destroy (lastSegment);
        ropeSegments.RemoveLast();
        JoinLastSegment ();
    }
    
    void JoinLastSegment () {
        LinkedListNode<GameObject> last = ropeSegments.Last;
        if (last == null) {
            return;
        }
        
        Rigidbody lastRigidbody = last.Value.GetComponent<Rigidbody> ();
        ropeTop.GetComponent<ConfigurableJoint> ().connectedBody = lastRigidbody;
    }
    
    #endregion
}
