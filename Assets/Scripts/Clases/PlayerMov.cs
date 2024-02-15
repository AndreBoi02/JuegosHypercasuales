using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    //El código contiene referencias del script que el profe nos enseñó para saber cómo usar el New InputSystem

    //Declaramos una
    private PlayerInputActions playerInputActions;

    private Rigidbody2D rb;

    [SerializeField] private float jumpForce;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        playerInputActions.Enable();
        playerInputActions.Mov.Jump.performed += Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
