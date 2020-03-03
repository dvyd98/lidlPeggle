using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static bool gameOver = false;

    private GameObject shooter;
    private ShooterScript shooterScript;
    private GameObject textBallCounter;
    // Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        shooterScript = shooter.GetComponent<ShooterScript>();
        shooterScript.onBallFired.AddListener(updateCounter);

        shooterScript.onOutOfBalls.AddListener(setGameOver);

        GameObject.FindGameObjectWithTag("Catcher").GetComponent<CatcherScript>().onBallCaught.AddListener(freeBall);

        textBallCounter = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
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
}
