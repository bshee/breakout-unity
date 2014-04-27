using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
  
  public GameObject player;
  public int points;
  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  void OnCollisionEnter2D(Collision2D collision) {  
    player.GetComponent<ScoreControl>().UpdateScore(points);
    Destroy(gameObject);
  }
}
