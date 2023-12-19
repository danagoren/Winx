using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public GameObject Bloom;
    [SerializeField] public GameObject Flora;
    [SerializeField] public GameObject Stella;


    private Transform lastPlayerTransform;
    private float moveSpeed = 5f;

    void Start()
    {
        Bloom.SetActive(false);
        Flora.SetActive(false);
        Stella.SetActive(false);
        InitializePlayers();
    }

    void InitializePlayers()
    {
        int random = UnityEngine.Random.Range(0, 3);
        if (random == 0)
        {
            Bloom.SetActive(true);
        }
        else if (random == 1)
        {
            Flora.SetActive(true);
        }
        else if (random == 2)
        {
            Stella.SetActive(true);
        }
    }

    void TogglePlayers()
    {
        if (Bloom.activeSelf == true)
        {
            Bloom.SetActive(false);
            Flora.SetActive(true);
            return;
        }
        if (Flora.activeSelf == true)
        {
            Flora.SetActive(false);
            Stella.SetActive(true);
            return;
        }
        if (Stella.activeSelf == true)
        {
            Stella.SetActive(false);
            Bloom.SetActive(true);
        }
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;
        if (Bloom.activeSelf == true)
        {
            Bloom.transform.Translate(movement);
            Flora.transform.position = Bloom.transform.position;
            Stella.transform.position = Bloom.transform.position;
        }
        if (Flora.activeSelf == true)
        {
            Flora.transform.Translate(movement);
            Bloom.transform.position = Flora.transform.position;
            Stella.transform.position = Flora.transform.position;
        }
        if (Stella.activeSelf == true)
        { 
            Stella.transform.Translate(movement);
            Flora.transform.position = Stella.transform.position;
            Bloom.transform.position = Stella.transform.position;
        }
    }

    void OnMouseDown()
    {
        TogglePlayers();
    }
}
