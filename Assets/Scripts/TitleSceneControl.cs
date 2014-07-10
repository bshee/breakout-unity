using UnityEngine;
using System.Collections;

public class TitleSceneControl : MonoBehaviour {

  public AudioClip titleSound;
  
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space)) {
      AudioManager.PlaySound(titleSound);
      
      Application.LoadLevel("Level1");     
    }   
	}
}
