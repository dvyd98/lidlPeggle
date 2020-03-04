using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public enum GameControllerElements { UI }
    public enum UIElements { TextBallCount, TextScore }
    public static bool gameOver = false;
    public int score = 0;

    private GameObject shooter;
    private ShooterScript shooterScript;
    private GameObject textBallCounter;
    private GameObject textScore;
    // Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        shooterScript = shooter.GetComponent<ShooterScript>();
        shooterScript.onBallFired.AddListener(updateCounter);

        shooterScript.onOutOfBalls.AddListener(setGameOver);

        GameObject.FindGameObjectWithTag("Catcher").GetComponent<CatcherScript>().onBallCaught.AddListener(freeBall);

        PeggleScript.onPeggleGot.AddListener(increaseScore);

        textBallCounter = transform.GetChild((int)GameControllerElements.UI).GetChild((int)UIElements.TextBallCount).GetChild(0).gameObject;
        textScore = transform.GetChild((int)GameControllerElements.UI).GetChild((int)UIElements.TextScore).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateCounter(int value)
    {
        textBallCounter.GetComponent<UnityEngine.UI.Text>().text = "Balls left: " + value.ToString();
    }

    void setGameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");
    }

    void freeBall()
    {
        updateCounter(++shooterScript.ballsLeft);
    }

    void increaseScore(int points)
    {
        score += points;
        textScore.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();
    }
}
