using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerController : MonoBehaviour
{
    
    private PlayerGroundCheck PlayerGroundCheck;
    private Rigidbody2D rb;

    private float Gravity = 7f;
    private float speed = 5f;
    void Start()
    {
        PlayerGroundCheck = GetComponent<PlayerGroundCheck>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {

    }

    public void frame()
    {
        move(Input.GetAxisRaw("Horizontal"));
    }

   public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, Gravity);
    }

    private void move(float moveInput)
    {
        rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
    }
}
