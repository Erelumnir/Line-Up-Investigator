using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour {

    // Variables
    [Header("Setup")]
    public CameraController camC;
    public Transform mapZoom;
    public Canvas mapCanvas;

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
        mapCanvas.gameObject.SetActive(true);
    }

    void OnMouseDown()
    {
        if (hasReset == false)
        {
            camC.newCamPos = mapZoom;
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
        mapCanvas.gameObject.SetActive(false);
    }
}
