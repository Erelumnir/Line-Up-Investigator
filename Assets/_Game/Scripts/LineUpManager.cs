using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LineUpManager : MonoBehaviour {

    // Variables
    [Header("Setup")]
    public CameraController camC;
    public Transform LineUpZoom;
    public Canvas lineupCanvas;
    public Button arrestButton;
    public Canvas inGameUI;
    public Canvas lineUpUI;

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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (hasReset == false)
            {
                camC.newCamPos = LineUpZoom;
                EnableButtons();
                hasReset = true;
            }
        }
    }

    public void resetCameraPosition()
    {
        if (hasReset == true)
        {
            camC.newCamPos = camC.oldCamPos;
            DisableButtons();
            hasReset = false;
        }
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
        lineupCanvas.gameObject.SetActive(false);
    }

    void EnableButtons()
    {
        arrestButton.gameObject.SetActive(true);
        inGameUI.gameObject.SetActive(false);
        lineUpUI.gameObject.SetActive(true);
    }

    void DisableButtons()
    {
        arrestButton.gameObject.SetActive(false);
        inGameUI.gameObject.SetActive(true);
        lineUpUI.gameObject.SetActive(false);

    }
}
