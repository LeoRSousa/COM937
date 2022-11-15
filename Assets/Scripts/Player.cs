using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRb;
    BoxCollider2D boxCollider;
    float playerVelo = 5;

    private Vector2 playerInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Andar();
    }

    void Andar()
    {
        playerRb.velocity = new Vector2(playerInput.x * playerVelo, playerInput.y * playerVelo);
    }
    
    void OnMove(InputValue inputValue)
    {
        playerInput = inputValue.Get<Vector2>();
    }
}
