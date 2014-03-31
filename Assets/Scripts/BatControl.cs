using UnityEngine;
using System.Collections;

public class BatControl : MonoBehaviour {

  [Range(0, 4)]
  public float speed;
  
	// Use this for initialization
	void Start() {
	}
	
	// Update is called once per frame
	void Update() {
    /*Vector3 currentPos = transform.position;
    float dir = Input.GetAxis("Horizontal");
    
    // need to bound by x coordinates
    float newX = currentPos.x + dir * speed * Time.deltaTime;
    
    if (newX < minBounds.x) {
      newX = minBounds.x;      
    }
    else if (newX > maxBounds.x) {
      newX = maxBounds.x;
    } */
    
    //transform.position = new Vector3(newX, currentPos.y, 0);
	}
  
  // fun with physics
  void FixedUpdate() {
    rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
  }
}
