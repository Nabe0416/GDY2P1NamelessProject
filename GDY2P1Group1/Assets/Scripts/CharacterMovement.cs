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

    [SerializeField]
    private bool TestOnly;

    [SerializeField]
    private GameObject tempThrowObj;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        AdjustRb();
    }

    #region Set Rigidbody properties.
    private void AdjustRb()
    {
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }
    #endregion

    #region Movement.
    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.MovePosition((Vector2)this.transform.position + new Vector2(x, y) * MoveSpeed * Time.deltaTime);
        
    }
    #endregion

    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        dir = (GetMousePosition() - (Vector2)transform.position).normalized;
        characterSprite.transform.up = dir;
        if(Input.GetMouseButtonDown(0))
        {
            TempThrowSmt();
        }
    }

    private void TempThrowSmt()
    {
        var obj = Instantiate(tempThrowObj, (Vector2)this.transform.position + (GetMousePosition() - (Vector2)transform.position).normalized, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce((GetMousePosition() - (Vector2)transform.position).normalized * 5, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public Transform GetPlayerTransform()
    {
        return transform;
    }
}
