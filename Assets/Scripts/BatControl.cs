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


  void EnforceBounds() {
    Vector3 newPosition = transform.position;
    Camera main = Camera.main;
    Vector3 cameraPos = main.transform.position;

    // change width to be the renderer's as that is the main reason for
    BoxCollider2D box = GetComponent<Collider2D>() as BoxCollider2D;
    float width = box.size.x;

    float xDist = main.aspect * main.orthographicSize;
    float xMax = cameraPos.x + xDist - width / 2;
    float xMin = cameraPos.x - xDist + width / 2;


    if (newPosition.x < xMin || newPosition.x > xMax) {
      newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
      transform.position = newPosition;
      GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
  }
  
  // fun with physics
  void FixedUpdate() {
    GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
    EnforceBounds();
  }
}
