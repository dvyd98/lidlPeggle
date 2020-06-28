using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallScript : MonoBehaviour
{
    public UnityEvent onOffScreen = new UnityEvent();
    public Rigidbody2D rigid;
    public Vector2 velocity;

    private bool firstPauseFrame = true;
    private bool firstPlayFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.menu && !GameControllerScript.gameOver)
        {
            firstPauseFrame = true;
            if (firstPlayFrame)
            {
                firstPlayFrame = false;
                rigid.velocity = velocity;
                rigid.isKinematic = false;
            }
            if (!GetComponent<Renderer>().isVisible)
            {
                despawnBall();
            }
        }
        else
        {
            firstPlayFrame = true;
            if (firstPauseFrame)
            {
                firstPauseFrame = false;
                velocity = rigid.velocity;
                rigid.velocity = new Vector2(0f, 0f);
                rigid.isKinematic = true;
            }
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
