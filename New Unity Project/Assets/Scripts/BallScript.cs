using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallScript : MonoBehaviour
{
    public UnityEvent onOffScreen = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            despawnBall();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        if (col.gameObject.tag == "Catcher") despawnBall();
    }

    void despawnBall()
    {
        onOffScreen.Invoke();
        Destroy(gameObject);
    }
}
