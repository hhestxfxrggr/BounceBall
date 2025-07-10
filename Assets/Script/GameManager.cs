using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform SpawnPoint;
    private PlayerController PlayerController;
    public GameObject PlayerPrefab;

    private GameObject player;
    void Start()
    {
        initialize();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController.frame();
    }

    public void initialize()
    {
        player = Instantiate(PlayerPrefab, SpawnPoint.position, Quaternion.identity);
        player.GetComponent<SpriteRenderer>().color = Color.yellow;

        PlayerController = player.GetComponent<PlayerController>();

        if (PlayerController != null)
        {
            Debug.Log("ok");
        }
        else Debug.Log("None");
    }
}
