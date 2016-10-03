using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float SmoothTime = 5.0f;
    public float verticalOffset = 5.0f;
    
    private Camera followCamera;
    
    // Use this for initialization
    void Start () {
        followCamera = Camera.main;
    }
    
    // Update is called once per frame
    void Update () {
        Vector3 cameraPosition = followCamera.transform.position;
        
        cameraPosition.x = transform.position.x;
        cameraPosition.y = transform.position.y + verticalOffset;
              
        followCamera.transform.position = Vector3.Lerp (followCamera.transform.position, cameraPosition, SmoothTime * Time.deltaTime);
    }
}
