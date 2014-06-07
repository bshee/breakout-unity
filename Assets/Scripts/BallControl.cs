using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {
  public float speed;
  
  private Vector3 startPosition;
	// Use this for initialization
	void Start () {
    rigidbody2D.velocity = Vector3.down * speed;
    startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
    //transform.position += velocity * Time.deltaTime;
	}
  
  void FixedUpdate() {
  }
  
  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.collider.tag == "Lose") {
      GameObject player = GameObject.Find("Player");
      PlayerControl control = player.GetComponent<PlayerControl>();
      control.UpdateLives(-1);
      
      if (!control.IsGameOver()) {
        Reset();
      }
    }
    else {
      rigidbody2D.velocity = speed * Vector3.Reflect(collision.relativeVelocity, collision.contacts[0].normal).normalized;
      //Debug.Log(rigidbody2D.velocity);
      
      if (rigidbody2D.velocity.y == 0) {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Random.value * 2 - 1);
      }
    }
  }
  
  void Reset() {
    transform.position = startPosition;
    rigidbody2D.velocity = Vector2.up * -speed;
  }
}
