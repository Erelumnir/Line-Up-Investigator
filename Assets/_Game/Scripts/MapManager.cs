using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour {

    // Variables
    [Header("Setup")]
    public CameraController camC;
    public Transform mapZoom;
    public Canvas mapCanvas;
    public Canvas popupCanvas;

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
            mapCanvas.gameObject.SetActive(true);
            rend.material.color = hoverColor;
        }
    }

    public void OnMouseDown()
    {
        if (hasReset == false)
        {
            camC.newCamPos = mapZoom;
            hasReset = true;
            popupCanvas.gameObject.SetActive(true);
        }
        else if (hasReset == true)
        {
            camC.newCamPos = camC.oldCamPos;
            hasReset = false;
            popupCanvas.gameObject.SetActive(false);
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        mapCanvas.gameObject.SetActive(false);
    }
    public void LoadMapScene()
    {
        SceneManager.LoadScene("Level_01_Map");
    }
}
