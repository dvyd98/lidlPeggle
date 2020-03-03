﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeggleScript : MonoBehaviour
{
    public enum STATE{
        ALIVE, DYING, DEAD
    }

    public int state;
    private float deathTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        state = (int)STATE.ALIVE;
    }

    // Update is called once per frame
    void Update()
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

    void OnCollisionEnter2D(Collision2D col)
    {
        state = (int)STATE.DYING;
    }
}
