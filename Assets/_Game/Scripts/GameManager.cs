using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Variables
	public List <GameObject> selectedPerps;

	public void ArrestPerps(){
		if (selectedPerps != null) {
			// Destroy all GameObjects in List
			foreach (GameObject selectedPerp in selectedPerps) {
				selectedPerps.Remove (selectedPerp);
				Destroy (selectedPerp, 0.5f);
			}
		} else {
			return;
		}
	}
}