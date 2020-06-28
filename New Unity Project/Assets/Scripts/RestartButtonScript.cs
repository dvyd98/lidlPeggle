using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButtonScript : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Restart()
    {
        GameControllerScript.menu = false;
        GameControllerScript.gameOver = false;
        GameControllerScript.gameWin = false;
        ShooterScript.ballsLeft = 1;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
