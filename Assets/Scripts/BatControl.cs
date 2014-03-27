using UnityEngine;
using System.Collections;

public class BatControl : MonoBehaviour {

  [Range(0, 4)]
  public float speed;
  
  private int width;
  //private int height = 16;
  private float direction;
  
  private Vector3 minBounds;
  private Vector3 maxBounds;
  
	// Use this for initialization
	void Start() {
    width = 32;
    minBounds = Camera.main.ScreenToWorldPoint(new Vector3(width/2, 0, 10));
    maxBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - width/2, Screen.height, 10));
    Debug.Log(minBounds.ToString());
    //Debug.Log("Camera pixel height " + Camera.main.pixelHeight);
    //Debug.Log("Camera pixel width " + Camera.main.pixelWidth);
    //Debug.Log(Camera.main.WorldToScreenPoint(transform.position).ToString()) ;
    //Vector3 pos = new Vector3(Screen.width / 2, 10, 10);
    //transform.position = Camera.main.ScreenToWorldPoint(pos);
	}
	
	// Update is called once per frame
	void Update() {
    Vector3 currentPos = transform.position;
    float dir = Input.GetAxis("Horizontal");
    
    // need to bound by x coordinates
    float newX = currentPos.x + dir * speed * Time.deltaTime;
    
    if (newX < minBounds.x) {
      newX = minBounds.x;      
    }
    else if (newX > maxBounds.x) {
      newX = maxBounds.x;
    }
    
    transform.position = new Vector3(newX, currentPos.y, 0);
	}
  
  // fun with physics
  void FixedUpdate() {
    
  }
}
