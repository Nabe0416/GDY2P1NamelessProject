using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //SerializeField can visualize the variable below in the inspector
    [SerializeField]
    private float MoveSpeed = 5;

    [SerializeField]
    private GameObject characterSprite;

    private Rigidbody2D rb;

    //The direction that the character is facing.
    private Vector2 dir;

    private void Start()
    {
        rb = this.gameObject.AddComponent<Rigidbody2D>();
        AdjustRb();
    }

    private void AdjustRb()
    {
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Movement()
    {
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
        dir = (GetMousePosition() - (Vector2)transform.position).normalized;
        characterSprite.transform.up = dir;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public Transform GetPlayerPosition()
    {
        return transform;
    }
}
