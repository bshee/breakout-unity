using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {
  public float speed;
  public float resetDelay;
  
  private Vector3 startPosition;
	// Use this for initialization
	void Start () {
    GetComponent<Rigidbody2D>().velocity = Vector3.down * speed;
    startPosition = transform.position;
	}

  void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Lose") {
      PlayerControl.UpdateLives(-1);
      GetComponent<Rigidbody2D>().velocity = Vector2.zero;

      if (!PlayerControl.IsGameOver()) {
        Invoke("Reset", resetDelay);
      }
    }
  }
  
  void OnCollisionEnter2D(Collision2D collision) {
    GetComponent<AudioSource>().Play();
    
    GetComponent<Rigidbody2D>().velocity = speed * Vector3.Reflect(collision.relativeVelocity, collision.contacts[0].normal).normalized;
    //Debug.Log(rigidbody2D.velocity);
    
    if (GetComponent<Rigidbody2D>().velocity.y == 0) {
      GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Random.value * 2 - 1);
    }
  }
  
  void Reset() {
    transform.position = startPosition;
    GetComponent<Rigidbody2D>().velocity = Vector2.up * -speed;
  }
}
