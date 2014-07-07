using UnityEngine;
using System.Collections;

// flashes text and also goes to next scene when spacebar is pressed
public class PromptText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space)) {
      Application.LoadLevel("Level1");
    }
	}
}
