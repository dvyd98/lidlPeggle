using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatcherScript : MonoBehaviour
{
    public UnityEvent onBallCaught = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        onBallCaught.Invoke();
        Debug.Log("Caught the ball");
    }
}
