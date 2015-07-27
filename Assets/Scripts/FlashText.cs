using UnityEngine;
using System.Collections;

// Flashes text by alternately fading out and fading in text.
public class FlashText : MonoBehaviour {
  
  [Range(0.1f, 10f)]
  public float fadeDuration = 1f;

	void Start () {
    StartCoroutine(FadeOut());
	}
  
  IEnumerator FadeOut() {
    Color original = GetComponent<GUIText>().color;
    
    for (float time = 0f; time < 1.0f; time += Time.deltaTime / fadeDuration) {
      Color newColor = Color.Lerp(original, Color.clear, time);
      GetComponent<GUIText>().color = newColor;
      yield return null;
    }
    
    StartCoroutine(FadeIn());
  }
  
  IEnumerator FadeIn() {
    Color original = GetComponent<GUIText>().color;
    
    for (float time = 0f; time < 1f; time += Time.deltaTime / fadeDuration) {
      Color newColor = Color.Lerp(original, Color.white, time);
      GetComponent<GUIText>().color = newColor;
      yield return null;
    }
    
    StartCoroutine(FadeOut());
  }
}
