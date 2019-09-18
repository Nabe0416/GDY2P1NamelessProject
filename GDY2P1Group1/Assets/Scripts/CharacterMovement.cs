using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //SerializeField can visualize the variable below in the inspector
    [SerializeField]
    private float MoveSpeed = 5;//Declare a float

    private Rigidbody2D rb;//Declare a rigidbody2d, it's a component of a gameobject
    private SpriteRenderer sr;

    /// <summary>
    /// This method will be run after the Awake method. Awake method will be run after this gameobject is loaded
    /// </summary>
    private void Start()
    {
        rb = this.gameObject.AddComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        AdjustRb();
    }

    private void AdjustRb()
    {
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    /// <summary>
    /// This is the function which detects the input of player and react on it.
    /// </summary>
    private void Movement()
    {
        /**
        if(Input.GetKey(KeyCode.W))
        {
            rb.MovePosition((Vector2)this.transform.position + new Vector2(0, MoveSpeed * Time.deltaTime));
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.MovePosition((Vector2)this.transform.position + new Vector2(0, -MoveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition((Vector2)this.transform.position + new Vector2(-MoveSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition((Vector2)this.transform.position + new Vector2(MoveSpeed * Time.deltaTime, 0));
        }
        **/

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.MovePosition((Vector2)this.transform.position + new Vector2(x, y) * MoveSpeed * Time.deltaTime);
    }

    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        transform.up = ((GetMousePosition() - (Vector2)transform.position).normalized);
    }

    /// <summary>
    /// This method will be call per frame, after method Update is called.
    /// </summary>
    private void FixedUpdate()
    {
        Movement();
    }
}
