using UnityEngine;
using System.Collections;

public class ScoreControl : MonoBehaviour {
  
  private int score;
  public GameObject text;
  
	void Start () {
    score = 0;
    text.guiText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  public void UpdateScore(int points) {
    score += points;
    text.guiText.text = "Score: " + score;
  }
}
