using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EvidenceManager : MonoBehaviour {

    // Variables
    [Header("Setup")]
    public CameraController camC;
    public Transform EvidenceZoom;
    public Canvas evidenceCanvas;
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
            evidenceCanvas.gameObject.SetActive(true);
            rend.material.color = hoverColor;
        }
    }
    void OnMouseDown()
    {
        if (hasReset == false)
        {
            camC.newCamPos = EvidenceZoom;
            hasReset = true;
            // POPUP 
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
        evidenceCanvas.gameObject.SetActive(false);
    }
    public void LoadEvidenceScene()
    {
        SceneManager.LoadScene("Level_01_Evidence");
    }
}
