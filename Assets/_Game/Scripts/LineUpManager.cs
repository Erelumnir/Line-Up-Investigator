using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineUpManager : MonoBehaviour {

    // Variables
    [Header("Setup")]
    public CameraController camC;
    public Transform LineUpZoom;
    public Canvas lineupCanvas;
    public Button arrestButton;

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
        if (hasReset)
        {
            return;
        }
        else
        {
            lineupCanvas.gameObject.SetActive(true);
            rend.material.color = hoverColor;
        }
    }

    public void OnMouseDown()
    {
        if (hasReset == false)
        {
            camC.newCamPos = LineUpZoom;
            EnableArrest();
            hasReset = true;
        }
        else if (hasReset == true)
        {
            camC.newCamPos = camC.oldCamPos;
            DisableArrest();
            hasReset = false;
        }
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
        lineupCanvas.gameObject.SetActive(false);
    }

    void EnableArrest()
    {
        arrestButton.gameObject.SetActive(true);
    }

    void DisableArrest()
    {
        arrestButton.gameObject.SetActive(false);
    }
}
