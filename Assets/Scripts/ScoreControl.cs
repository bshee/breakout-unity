using UnityEngine;
using System.Collections;

public class ScoreControl : MonoBehaviour {
  
  private int score;
  
	void Start () {
    score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  public void UpdateScore(int points) {
    score += points;
    Debug.Log(score + ": " + points);
  }
}
