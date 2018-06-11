using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitnessManager : MonoBehaviour {

	// Variables
    [Header("Color Setup")]
    public Color hoverColor;
    private Color startColor;

    private Renderer rend;
    public Text statement1;
    public Text statement2;
    public Text statement3;

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
            StartCoroutine(ShowStatement());
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
            isActive = false;
            hasClicked = false;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    IEnumerator ShowStatement() {
        // Show Witness Statements
        statement1.text = "Witness 1: I saw a blue capsule leaving the house!";
        yield return new WaitForSeconds(5);
        statement1.text = "";
        statement2.text = "Witness 2: I heard a motor pull up to the house.";
        yield return new WaitForSeconds(5);
        statement2.text = "";
        statement3.text = "Witness 3: I didn't see or hear anything.";
        yield return new WaitForSeconds(5);
        statement3.text = "";
    }
}
