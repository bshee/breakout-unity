using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {
  
  private GameObject player;
  public int points;
  public AudioClip breakSound;
  
	// Use this for initialization
	void Start () {
    player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  void OnCollisionEnter2D(Collision2D collision) {  
    AudioManager.PlaySound(breakSound);
    player.GetComponent<PlayerControl>().UpdateScore(points);
    Destroy(gameObject);
  }
}
