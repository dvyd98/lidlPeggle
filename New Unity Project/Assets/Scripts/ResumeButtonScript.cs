using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResumeButtonScript : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(unPause);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.1f);
        GameControllerScript.pause = false;
        SceneManager.UnloadSceneAsync(3);
    }

    void unPause()
    {
        StartCoroutine(waiter());
    }
}
