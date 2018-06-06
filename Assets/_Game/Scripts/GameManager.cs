using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Variables
	[Header("Game Settings")]
	// Changes per level
	public int suspectCounter = 1;

	[Header ("Setup")]
	public List <GameObject> selectedPerps;

	public PerpAttributes perpA;

	void Update(){
		// Counter Reaches 0
		if (suspectCounter <= 0){
			Win ();
		}
	}

	public void ArrestPerps(){
		if (selectedPerps != null) {
			// Destroy all GameObjects in List
			foreach (GameObject selectedPerp in selectedPerps) {
				perpA = selectedPerp.GetComponent<PerpAttributes> ();

				// Check if the perp is guilty
				if (perpA.isGuilty) {
					suspectCounter -= 1;
					selectedPerps.Remove (selectedPerp);
					Destroy (selectedPerp, 0.5f);
				} else if (!perpA.isGuilty) {
					Lose ();
				}
			}
		} 
		{
			return;
		}
	}

	void Win(){
		// WIN
		Debug.Log("You're promoted!");
	}

	void Lose(){
		//LOSE
		Debug.Log("You're fired!");
	}
}