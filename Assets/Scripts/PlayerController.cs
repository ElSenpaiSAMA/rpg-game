using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private SpriteRenderer spriteRenderer; 
    [SerializeField] private Sprite spriteW; 
    [SerializeField] private Sprite spriteS; 
    [SerializeField] private Sprite spriteA; 
    [SerializeField] private Sprite spriteD; 

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        PlayerInput();
        ChangeSprite();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void ChangeSprite()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            spriteRenderer.sprite = spriteW;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            spriteRenderer.sprite = spriteS;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.sprite = spriteA;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.sprite = spriteD;
        }
    }
}

