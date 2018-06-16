using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Header("Camera Setup")]
    public Transform newCamPos;
    public Transform oldCamPos;

    public float camSpeed = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Moves the camera
        if (newCamPos != null)
        {
            transform.position = Vector3.Lerp(transform.position, newCamPos.position, camSpeed * Time.deltaTime);
        }
        else
        {
            return;
        }
	}
}