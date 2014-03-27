using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {
  public float speed;
  
  private Vector3 velocity;
  
	// Use this for initialization
	void Start () {
    velocity = new Vector3(0, speed * Mathf.Sin(-90), 0);
	}
	
	// Update is called once per frame
	void Update () {
    transform.position += velocity * Time.deltaTime;
	}
  
  void OnCollisionEnter(Collision collision) {
    Debug.Log("Ouch!");
  }
}
