using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

  private static PlayerControl instance = null;

  public static PlayerControl Instance {
    get {
      return instance;
    }
  }
  
  public GUIText scoreText;
  public GUIText livesText;
  
  private int score;
  private int lives;
  private bool gameOver;
  // private GameObject bat;
  //private GameObject ball;
  private int breakables;
  private int breakCount;

	void Start () {
    instance = this;

    score = 0;
    lives = 3;
    scoreText.text = "Score: " + score;
    livesText.text = "Lives: " + lives;
    gameOver = false;

    //bat = GameObject.Find("Bat");
    //ball = GameObject.Find("Ball");

    breakables = GameObject.FindGameObjectsWithTag("Breakable").Length;
    breakCount = 0;
	}

  public static bool IsGameOver() {
    return Instance.gameOver;
  }

  public static void GameOver() {
    if (Instance.gameOver) {
      Debug.Log("Game over called when game should already be over.");
    }

    Instance.gameOver = true;

    // Disable bat and ball
    //Instance.bat.GetComponent<BatControl>().enabled = false;
    //ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    
    Application.LoadLevel("Title");
  }
	
  public static void UpdateLives(int delta) {
    Instance.lives += delta;
    Instance.livesText.text = "Lives: " + Instance.lives;

    if (Instance.lives <= 0) {
      GameOver();
    }
  }

  public static void IncreaseBreakablesCount() {
    Instance.breakables++;
  }

  public static void UpdateBreakCount() {
    Instance.breakCount++;
    
    // Player wins
    if (Instance.breakCount == Instance.breakables) {
      Application.LoadLevel("Winner");
    }
  }
  
  public static void UpdateScore(int points) {
    Instance.score += points;
    Instance.scoreText.text = "Score: " + Instance.score;
  }
}
