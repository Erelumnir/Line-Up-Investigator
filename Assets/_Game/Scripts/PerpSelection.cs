using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerpSelection : MonoBehaviour {

	// Variables
	[Header("Selection Settings")]
	public Color hoverColor;
	public Color selectedColor;
	private Color startColor;

	private Renderer rend;
	private bool IsSelected = false;

	[Header("Setup")]
	public GameManager gameManager;

	void Start(){
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
	}

	void OnMouseEnter(){
		// When hovering over a perp
		if (!IsSelected) {
			rend.material.color = hoverColor;
		}
	}

	void OnMouseDown(){
		// When Selecting a perp
		if (!IsSelected) {
			AddSelection (this.gameObject);
		}
		else if (IsSelected) {
			RemoveSelection (this.gameObject);
		}
	}

	void OnMouseExit(){
		// Reset color if not selected
		if (!IsSelected) {
			rend.material.color = startColor;
		}
	}

	void AddSelection(GameObject obj){
		// Adds Selected GameObject to a list
		rend.material.color = selectedColor;
		IsSelected = true;
		gameManager.selectedPerps.Add(obj);
		Debug.Log ("GameObject Added");
	}

	void RemoveSelection(GameObject obj){
		// Removes Selected GameObject to a list
		rend.material.color = startColor;
		IsSelected = false;
		gameManager.selectedPerps.Remove(obj);
		Debug.Log ("GameObject Removed");
	}
}