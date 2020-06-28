using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(play);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void play()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
