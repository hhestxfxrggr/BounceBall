using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    private GameObject groundCheck;           // 발밑 위치
    private float checkRadius = 0.01f;        // 감지 반지름
    public LayerMask groundLayer;           // 감지할 레이어

    bool isGrounded;

    private void Start()
    {
        groundCheck = GameObject.Find("GroundCheck");
        groundLayer = LayerMask.GetMask("Ground");
    }
    public bool IsOnGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, groundLayer);
        Debug.Log("LayerMask 값: " + groundLayer.value);
        return isGrounded;

    }

    public void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
        }
    }

    public void SetIsGround(bool isGround)
    {
        isGrounded = isGround;
    }
}
