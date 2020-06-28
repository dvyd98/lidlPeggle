using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CatcherScript : MonoBehaviour
{
    public UnityEvent onBallCaught = new UnityEvent();
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.menu && !GameControllerScript.gameOver)
        {
            anim.enabled = true;
        }
        else anim.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        onBallCaught.Invoke();
        Debug.Log("Caught the ball");
    }
}
