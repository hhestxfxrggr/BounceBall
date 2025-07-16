using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform SpawnPoint;
    private PlayerController PlayerController;
    public GameObject PlayerPrefab;

    private PlayerGroundCheck GroundCheck;           // 발밑 위치
    private float checkRadius = 0.01f;        // 감지 반지름
    public LayerMask groundLayer;           // 감지할 레이어

    private GameObject player;
    private bool GameOver = false;
    void Start()
    {
        initialize();
        groundLayer = LayerMask.GetMask("BrokenBlock","Trap");
    }

    // Update is called once per frame
    void Update()
    { 

        if(GameOver && GroundCheck != null)
        {
            return;
        }

        Collider2D hit = GroundCheck.CheckForGroundHit();
        if (hit != null)
        {
            switch (hit.gameObject.layer)
            {
                case 3:
                    PlayerController.Jump();
                    break;
                case 6:
                    BrokenBlock block = hit.GetComponent<BrokenBlock>();
                    Debug.Log("진입");
                    if (block != null) 
                    { 
                        Debug.Log("실행");
                        PlayerController.Jump();
                        block.BreakBlock();
                    }
                    break;
                case 7:
                    Debug.Log("트랩");
                    StartCoroutine(ResetPlayer());
                    break;
            }
        }
        if (!GameOver && PlayerController != null)
            PlayerController.frame();
    }
    IEnumerator ResetPlayer()
    {
        GameOver = true;
        Destroy(player);
        yield return null;           // 한 프레임 대기
        initialize();                // 안전하게 재생성
        GameOver = false;
    }

    public void initialize()
    {
        player = Instantiate(PlayerPrefab, SpawnPoint.position, Quaternion.identity);
        player.GetComponent<SpriteRenderer>().color = Color.yellow;

        PlayerController = player.GetComponent<PlayerController>();
        GroundCheck = player.GetComponent<PlayerGroundCheck>();

        if (PlayerController != null && GroundCheck != null)
        {
            Debug.Log("ok");
        }
        else Debug.Log("None");
    }
}
