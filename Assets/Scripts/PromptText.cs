using UnityEngine;
using System.Collections;

// flashes text and also goes to next scene when spacebar is pressed
public class PromptText : MonoBehaviour {
  
  
  public AudioClip titleSound;
  
  private float fadeDuration = 0.5f;

	// Use this for initialization
	void Start () {
    StartCoroutine(FadeEffect());
	}
  
  IEnumerator FadeEffect() {
    bool fadeOut = true;
    //bool fadeIn = false;
    
    while (true) {
      Color c = guiText.color;
      
      // Specific alpha values for alternating when almost done fading in/out
      if (fadeOut) {
        guiText.color = Color.Lerp(guiText.color, Color.clear, Time.deltaTime/fadeDuration);
        /* c.a -= Time.deltaTime/fadeDuration;
        */
        
        
        if (c.a <= 0.1f) {
          fadeOut = false;
        }
      }
      else { // fade in
        /*c.a += Time.deltaTime/fadeDuration; */
        
        guiText.color = Color.Lerp(guiText.color, Color.white, Time.deltaTime/fadeDuration);
        if (c.a >= 0.9f) {
          fadeOut = true;
        } 
      }
      
      //guiText.material.color = c;
      
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
