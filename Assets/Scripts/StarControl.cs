using UnityEngine;
using System.Collections;

// Destroy star upon collision with Bottom or Player
// Add point to Player if collided
public class StarControl : MonoBehaviour {

  public int points;
  public AudioClip bonusSound;

  [Range(0f, 1f)]
  public float bonusSoundVolume;

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Lose") {
      Destroy(gameObject);
    }
    else if (other.tag == "Player") {
      PlayerControl.UpdateScore(points);
      AudioManager.PlayOneShot(bonusSound, bonusSoundVolume);
      Destroy(gameObject);
    }
  }


  void OnDestroy() {
    PlayerControl.UpdateBreakCount();
  }
}
