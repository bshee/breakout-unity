using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
  public float speed;
  
  
	// Use this for initialization
	void Start () {
    rigidbody2D.velocity = new Vector3(0, speed * Mathf.Sin(-90), 0);
	}
	
	// Update is called once per frame
	void Update () {
    //transform.position += velocity * Time.deltaTime;
	}
  
  void FixedUpdate() {
  }
  
  void OnCollisionEnter2D(Collision2D collision) {
    rigidbody2D.velocity = Vector3.Reflect(collision.relativeVelocity, collision.contacts[0].normal);
  }
}
