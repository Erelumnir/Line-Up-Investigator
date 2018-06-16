using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueManager : MonoBehaviour {

    [Header("Setup")]
    public CameraController camC;
    public Transform morgueZoom;
    public Canvas morgueCanvas;

    [Header("Color Setup")]
    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    private bool hasReset = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        morgueCanvas.gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
        morgueCanvas.gameObject.SetActive(false);
    }
    void OnMouseDown()
    {
        if (hasReset == false)
        {
            camC.newCamPos = morgueZoom;
            hasReset = true;
        }
        else if (hasReset == true)
        {
            camC.newCamPos = camC.oldCamPos;
            hasReset = false;
        }
    }
}
