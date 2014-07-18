using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
  
  public int points;
  public GameObject star;

  [Range(0f, 1f)]
  public float starSpawnChance;
  public AudioClip breakSound;
  
  void OnCollisionEnter2D(Collision2D collision) {  
    // Check to spawn a star
    if (Random.value < starSpawnChance) {
      Instantiate(star, transform.position, Quaternion.identity);
      PlayerControl.IncreaseBreakablesCount();
    }

    AudioManager.PlaySound(breakSound);
    PlayerControl.UpdateScore(points);
    PlayerControl.UpdateBreakCount();
    

    Destroy(gameObject);
  }
}
