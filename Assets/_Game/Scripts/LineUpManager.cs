using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineUpManager : MonoBehaviour {

    // Variables
    [Header("Setup")]
    public CameraController camC;
    public Transform LineUpZoom;
    public Canvas lineupCanvas;

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
        lineupCanvas.gameObject.SetActive(true);
    }

    void OnMouseDown()
    {
        if (hasReset == false)
        {
            camC.newCamPos = LineUpZoom;
            hasReset = true;
        }
        else if (hasReset == true)
        {
            camC.newCamPos = camC.oldCamPos;
            hasReset = false;
        }
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
        lineupCanvas.gameObject.SetActive(false);
    }
}
