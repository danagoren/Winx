using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public GameObject OtherPlayer;
    [SerializeField] public GameObject ActivePlayer;

    private Transform lastPlayerTransform;
    private float moveSpeed = 5f; 

    void Start()
    {
        InitializePlayers();
    }

    void InitializePlayers()
    {
        if (UnityEngine.Random.Range(0, 3) == 0)
        {
            OtherPlayer.SetActive(false);
            ActivePlayer.SetActive(true);
            lastPlayerTransform = ActivePlayer.transform;
        }
        else
        {
            OtherPlayer.SetActive(true);
            ActivePlayer.SetActive(false);
            lastPlayerTransform = OtherPlayer.transform;
        }
    }

    void TogglePlayers()
    {
        OtherPlayer.SetActive(!OtherPlayer.activeSelf);
        ActivePlayer.SetActive(!ActivePlayer.activeSelf);

        if (ActivePlayer.activeSelf)
        {
            lastPlayerTransform = ActivePlayer.transform;
        }
        else
        {
            lastPlayerTransform = OtherPlayer.transform;
        }
    }

    void Update()
    {
        if (ActivePlayer.activeSelf)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;
        ActivePlayer.transform.Translate(movement);
    }

    void OnMouseDown()
    {
        TogglePlayers();
    }
}
