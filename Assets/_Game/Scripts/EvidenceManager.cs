using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceManager : MonoBehaviour {

    // Variables
    [Header("Color Setup")]
    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    [Header("Evidence Setup")]
    public Text evidence1;
    public Text evidence2;
    public Text evidence3;
    public Text evidence4;
    public Text evidence5;

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
        if (isActive && hasClicked)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, newCameraPos.position, cameraSpeed * Time.deltaTime);
            StartCoroutine(ShowEvidence());
        }
        else if (!hasClicked && !isActive)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, oldCameraPos.position, cameraSpeed * Time.deltaTime);
        }
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

    IEnumerator ShowEvidence()
    {
        // Show Witness Statements
        evidence1.text = "Evidence A: Peter is Santiago's brother.";
        yield return new WaitForSeconds(5);
        evidence1.text = "";
        evidence2.text = "Evidence B: Peter's car has been sighted near the house.";
        yield return new WaitForSeconds(5);
        evidence2.text = "";
        evidence3.text = "Evidence C: Peter was working with Alberto at the time of the murder.";
        yield return new WaitForSeconds(5);
        evidence3.text = "";
        evidence4.text = "Evidence D: Peter got picked up by Alberto.";
        yield return new WaitForSeconds(5);
        evidence4.text = "";
        evidence5.text = "Evidence E: Sevilla and Santiago claim to be both at home.";
    }
}
