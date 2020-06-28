using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public enum GameControllerElements { UI }
    public enum UIElements { TextBallCount, TextScore, TextOrangePeggle }
    public static bool gameOver = false;
    public static bool gameWin = false;
    public static bool menu = false;
    public int score = 0;
    public int OrangePegglesLeft;

    private GameObject shooter;
    private ShooterScript shooterScript;
    private GameObject textBallCounter;
    private GameObject textScore;
    private GameObject textOrangePeggles;
    // Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        shooterScript = shooter.GetComponent<ShooterScript>();
        shooterScript.onBallFired.AddListener(updateCounter);

        shooterScript.onOutOfBalls.AddListener(setGameOver);

        GameObject.FindGameObjectWithTag("Catcher").GetComponent<CatcherScript>().onBallCaught.AddListener(freeBall);

        PeggleScript.onPeggleGot.AddListener(increaseScore);
        OrangePeggleScript.onOrangePeggleGot.AddListener(updateOrangePeggleCount);

        textBallCounter = transform.GetChild((int)GameControllerElements.UI).GetChild((int)UIElements.TextBallCount).GetChild(0).gameObject;
        textScore = transform.GetChild((int)GameControllerElements.UI).GetChild((int)UIElements.TextScore).GetChild(0).gameObject;
        textOrangePeggles = transform.GetChild((int)GameControllerElements.UI).GetChild((int)UIElements.TextOrangePeggle).GetChild(0).gameObject;

        getOrangePegglesCount();
        updateOrangePeggleCount();
    }

    // Update is called once per frame
    void Update()
    {
        if (OrangePegglesLeft == 0)
        {
            gameWin = true;
            gameOver = true;
            SceneManager.LoadScene("WinUIMenu", LoadSceneMode.Additive);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (menu)
            {
                menu = false;
                SceneManager.UnloadSceneAsync(3);
            }
            else
            {
                menu = true;
                SceneManager.LoadScene("PauseUIMenu", LoadSceneMode.Additive);
            }
        }
    }

    void updateCounter(int value)
    {
        textBallCounter.GetComponent<UnityEngine.UI.Text>().text = "Balls left: " + value.ToString();
    }

    void setGameOver()
    {
        gameOver = true;
        menu = true;
        SceneManager.LoadScene("GameOverMenu", LoadSceneMode.Additive);
        Debug.Log("Game Over");
    }

    private void getOrangePegglesCount()
    {
        GameObject[] OrangePeggleCount = GameObject.FindGameObjectsWithTag("OrangePeggle");
        OrangePegglesLeft = OrangePeggleCount.Length + 1;
    }

    void freeBall()
    {
        updateCounter(++ShooterScript.ballsLeft);
    }

    void increaseScore(int points)
    {
        score += points;
        textScore.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();
    }

    void updateOrangePeggleCount()
    {
        textOrangePeggles.GetComponent<UnityEngine.UI.Text>().text = "Orange peggles left: " + --OrangePegglesLeft;
    }

    public static int getCurrentLvl()
    {
        int countLoaded = SceneManager.sceneCount;
        for (int i = 0; i < countLoaded; i++)
        {
            if (SceneManager.GetSceneAt(i).name == "Level1") return 1;
        }

        return 0;
    }
}
