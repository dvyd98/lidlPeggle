using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShooterScript : MonoBehaviour
{
    [System.Serializable]
    public class OnBallFiredEvent : UnityEvent<int>
    {

    }

    public GameObject projectile;

    public OnBallFiredEvent onBallFired = new OnBallFiredEvent();
    public UnityEvent onOutOfBalls = new UnityEvent();

    public int ballsLeft;
    public Boolean isBallAlive;
    // Start is called before the first frame update
    void Start()
    {
        isBallAlive = false;
        ballsLeft = 15;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameControllerScript.gameOver && !GameControllerScript.pause)
        {
            lookAtMouse();
            if (Input.GetMouseButtonUp(0) && !isBallAlive && ballsLeft > 0)
            {
                isBallAlive = true;
                onBallFired.Invoke(--ballsLeft);
                spawnProjectile();
            }
            else if (!isBallAlive && ballsLeft <= 0) onOutOfBalls.Invoke();
        }
    }
    
    private void spawnProjectile()
    {
        //spawns the projectile
        Vector3 rot = new Vector3(90f, 0, this.transform.rotation.z);
        GameObject obj = Instantiate(projectile, this.transform.position, Quaternion.Euler(rot));
        obj.GetComponent<BallScript>().onOffScreen.AddListener(refill);

        //adds the initial force in the correct direction
        Vector3 aux = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        Vector2 dir = new Vector2(aux.x, aux.y);
        dir.Normalize();

        obj.GetComponent<Rigidbody2D>().AddForce(dir * 1f, ForceMode2D.Impulse);
    }

    private void lookAtMouse()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 lookAt = mouseScreenPosition;

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }

    private void refill()
    {
        isBallAlive = false;
    }
}
