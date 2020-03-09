using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BluePeggleScript : PeggleScript
{
    public static UnityEvent onBluePeggleGot = new UnityEvent();

    override public void SetUp()
    {
        points = 5;
    }

    public override void ProcessEvents()
    {
        Debug.Log("Blue peggle hit event");
    }
}
