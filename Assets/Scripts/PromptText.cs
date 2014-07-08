using UnityEngine;
using System.Collections;

// flashes text and also goes to next scene when spacebar is pressed
public class PromptText : MonoBehaviour {
  
  
  public AudioClip titleSound;
  
  private float fadeDuration = 1f;

	// Use this for initialization
	void Start () {
    StartCoroutine(FadeEffect());
	}
  
  IEnumerator FadeEffect() {
    bool fadeOut = true;
    //bool fadeIn = false;
    
    while (true) {
      Color c = guiText.material.color;
      
      if (fadeOut) {
        c.a -= Time.deltaTime/fadeDuration;
        
        if (c.a <= 0) {
          fadeOut = false;
        }
      }
      else { // fade in
        c.a += Time.deltaTime/fadeDuration;
        if (c.a >= 1) {
          fadeOut = true;
        }
      }
      
      guiText.material.color = c;
      
      yield return null;
      //yield return new WaitForSeconds(0.05f);
    }
  }

	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space)) {
      //audio.Play();
      AudioManager.PlaySound(titleSound);
      
      Application.LoadLevel("Level1");
      
      
    }   
	}
}
