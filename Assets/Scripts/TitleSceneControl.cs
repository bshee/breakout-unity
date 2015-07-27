using UnityEngine;
using System.Collections;

public class TitleSceneControl : MonoBehaviour {

  public AudioClip titleSound;
  [Range(0.5f, 10f)]
  public float fadeDuration;

  private GameObject fader;
  private bool notFading;


  void Start() {
    fader = GameObject.FindWithTag("Fader");
    notFading = false;
  }


  IEnumerator FadeOut() {
    Color original = fader.GetComponent<GUITexture>().color;

    for (float time = 0f; time < 1f; time += Time.deltaTime / fadeDuration) {
      Color newColor = Color.Lerp(original, Color.black, time);
      fader.GetComponent<GUITexture>().color = newColor;
      yield return null;
    }

    Application.LoadLevel("Level1");     
  }
  
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Space) && !notFading) {
      notFading = true;
      AudioManager.PlaySound(titleSound);
      StartCoroutine(FadeOut());
      
    }   
	}
}
