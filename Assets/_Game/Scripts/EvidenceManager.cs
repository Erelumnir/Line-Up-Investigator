﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceManager : MonoBehaviour {

    // Variables
    [Header("Setup")]
    public CameraController camC;
    public Transform EvidenceZoom;
    public Canvas evidenceCanvas;

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
        evidenceCanvas.gameObject.SetActive(true);
    }

    void OnMouseDown()
    {
        if (hasReset == false)
        {
            camC.newCamPos = EvidenceZoom;
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
        evidenceCanvas.gameObject.SetActive(false);
    }
}
