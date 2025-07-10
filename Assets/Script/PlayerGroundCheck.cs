using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    private GameObject groundCheck;           // �߹� ��ġ
    private float checkRadius = 0.01f;        // ���� ������
    public LayerMask groundLayer;           // ������ ���̾�

    bool isGrounded;

    private void Start()
    {
        groundCheck = GameObject.Find("GroundCheck");
        groundLayer = LayerMask.GetMask("Ground");
    }
    public bool IsOnGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, groundLayer);
        Debug.Log("LayerMask ��: " + groundLayer.value);
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
