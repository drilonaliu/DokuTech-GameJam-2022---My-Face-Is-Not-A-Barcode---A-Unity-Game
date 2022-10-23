using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class Player : MonoBehaviour
{

    public int speed;
    public int rotationSpeed;
    public int hearts;
    public HealthBar healthbar;
    public Animator animator;

    private Rigidbody2D rigid_body;
    public Transform transform;
    static float angle = 270f;
    float last_angle = angle;

    void Start()
    {
        transform = GetComponent<Transform>();
        rigid_body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // float move = Input.GetAxis("Up");
        // float rotate = Input.GetAxis("Rotate");
        // last_angle = angle;
        // if (Mathf.Sign(move) >= 0)
        // {
        //     angle = Mathf.Round((angle + rotate) * 100f) / 100f;
        // }
        // else
        //     angle = Mathf.Round((angle - rotate) * 100f) / 100f;
        
        // if (Mathf.Abs(move) > 0)
        // {
        //     animator.SetFloat("Speed", Mathf.Abs(move));
        // }
        // else
        //     animator.SetFloat("Speed", 0);
        // Vector2 directional_vector = new Vector2(move * Mathf.Cos((angle * rotationSpeed) * Mathf.Deg2Rad) * speed, (move * Mathf.Sin(angle * rotationSpeed * Mathf.Deg2Rad) * speed));
        // rigid_body.velocity = directional_vector;
        // this.transform.Rotate(0f, 0f, (angle - last_angle) * rotationSpeed, Space.World);

         Vector2 directional_vector = new Vector2((Input.GetAxis("Horizontal")) * speed, (Input.GetAxis("Vertical")) * speed);
        rigid_body.velocity = directional_vector;
    }

    public void disablePlayerMovement()
    {
        speed = 0;
    }



    public bool isDead()
    {
        if (healthbar.lifeAmount() == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void removeHeart()
    {
        if (!isDead())
        {
            hearts--;
            healthbar.removeHeart();
        }

    }

    public void hideHearts()
    {
        healthbar.gameObject.SetActive(false);
    }

    public void showHearts()
    {
        healthbar.gameObject.SetActive(true);
    }


    public void reset()
    {
        transform.position = new Vector2(25.68f, -0.1f);
        speed = 10;
        healthbar.reset();
    }
}
