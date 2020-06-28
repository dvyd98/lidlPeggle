using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PeggleScript : MonoBehaviour
{
    public enum STATE{
        ALIVE, DYING, DEAD
    }
    public class OnPeggleGotEvent : UnityEvent<int>
    {

    }

    public int points = 5;

    public static OnPeggleGotEvent onPeggleGot = new OnPeggleGotEvent();

    public int state;
    private float deathTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        state = (int)STATE.ALIVE;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.menu)
        {
            if (state == (int)STATE.ALIVE);
            else if (state == (int)STATE.DYING)
            {
                deathTimer += Time.deltaTime;
                if (deathTimer % 60 > 2) state = (int)STATE.DEAD;
            }
            else if (state == (int)STATE.DEAD)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (state == (int)STATE.ALIVE)
        {
            state = (int)STATE.DYING;
            onPeggleGot.Invoke(points);
            ProcessEvents();
        }
    }

    public virtual void SetUp()
    {

    }

    public virtual void ProcessEvents()
    {

    }
}
