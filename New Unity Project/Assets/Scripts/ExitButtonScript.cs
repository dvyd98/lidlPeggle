using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonScript : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Quit()
    {
        Application.Quit();
    }
}
