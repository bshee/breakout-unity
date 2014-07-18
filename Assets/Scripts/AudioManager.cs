using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
  
  private static AudioManager instance = null;
  
  public static AudioManager Instance {
    get {
      return instance;
    }
  }
  
  void Awake() {
    if (instance != null && instance != this) {
      Destroy(this.gameObject);
    }
    else {
      instance = this;
      DontDestroyOnLoad(this.gameObject);
    }
  }
  
	public static void PlaySound(AudioClip clip) {
    instance.audio.clip = clip;
    instance.audio.Play();
  }

  public static void PlayOneShot(AudioClip clip, float volume) {
    Instance.audio.PlayOneShot(clip, volume);
  }
}
