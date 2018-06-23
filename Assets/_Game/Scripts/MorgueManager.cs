using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorgueManager : MonoBehaviour {

    [Header("Setup")]
    public CameraController camC;
    public Transform morgueZoom;
    public Canvas morgueCanvas;
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
            morgueCanvas.gameObject.SetActive(true);
            rend.material.color = hoverColor;
        }
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
        morgueCanvas.gameObject.SetActive(false);
    }
    public void OnMouseDown()
    {
        if (hasReset == false)
        {
            camC.newCamPos = morgueZoom;
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
    public void LoadMorgueScene()
    {
        SceneManager.LoadScene("Level_01_Morgue");
    }
}
