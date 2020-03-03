using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject projectile;
    public Boolean isBallAlive;
    // Start is called before the first frame update
    void Start()
    {
        isBallAlive = false;
    }

    // Update is called once per frame
    private void Update()
    {
        lookAtMouse();
        if (Input.GetMouseButtonUp(0) && !isBallAlive)
        {
            isBallAlive = true;
            spawnProjectile();
        }
    }

    private void spawnProjectile()
    {
        //spawns the projectile
        Vector3 rot = new Vector3(90f, 0, this.transform.rotation.z);
        GameObject obj = Instantiate(projectile, this.transform.position, Quaternion.Euler(rot));

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
}
