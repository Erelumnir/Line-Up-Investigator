using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpManager : MonoBehaviour {

    // Variables
    [Header("Color Setup")]
    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    [Header("Camera Setup")]
    public Camera cam;
    public Transform newCameraPos;
    public Transform oldCameraPos;

    public float cameraSpeed = 2f;

    private bool hasClicked = false;
    private bool isActive = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void Update()
    {
//        if (isActive && hasClicked)
//        {
//            cam.transform.position = Vector3.Lerp(cam.transform.position, newCameraPos.position, cameraSpeed * Time.deltaTime);
//        }
//        else if (!hasClicked && !isActive)
//        {
//            cam.transform.position = Vector3.Lerp(cam.transform.position, oldCameraPos.position, cameraSpeed * Time.deltaTime);
//        }
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseDown()
    {
        if (!hasClicked)
        {
            isActive = true;
            hasClicked = true;
        }

        else if (hasClicked)
        {
            hasClicked = false;
            isActive = false;
        }
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
