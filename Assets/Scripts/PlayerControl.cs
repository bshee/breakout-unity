using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
  
  public GUIText scoreText;
  public GUIText livesText;
  
  private int score;
  private int lives;
  private bool gameOver;
  private GameObject bat;
  private GameObject ball;
  private int breakables;
  private int breakCount;

	void Start () {
    score = 0;
    lives = 3;
    scoreText.text = "Score: " + score;
    livesText.text = "Lives: " + lives;
    gameOver = false;

    bat = GameObject.Find("Bat");
    ball = GameObject.Find("Ball");

    breakables = GameObject.FindGameObjectsWithTag("Breakable").Length;
    breakCount = 0;
	}

  public bool IsGameOver() {
    return gameOver;
  }

  public void GameOver() {
    if (gameOver) {
      Debug.Log("Game over called when game should already be over.");
    }

    gameOver = true;

    // Disable bat and ball
    bat.GetComponent<BatControl>().enabled = false;
    ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
  }
	
  public void UpdateLives(int delta) {
    lives += delta;
    livesText.text = "Lives: " + lives;

    if (lives <= 0) {
      GameOver();
    }
  }
  
  public void UpdateScore(int points) {
    score += points;
    scoreText.text = "Score: " + score;

    breakCount++;
    
    if(breakCount == breakables) {
      GameOver();
    }
  }
}
