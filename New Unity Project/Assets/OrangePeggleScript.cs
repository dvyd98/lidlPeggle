﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrangePeggleScript : PeggleScript
{
    public static UnityEvent onOrangePeggleGot = new UnityEvent();

    override public void SetUp()
    {
        points = 25;
    }//
}
