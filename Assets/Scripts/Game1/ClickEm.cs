using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickEm : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Camera _mainCamera;

    public float points;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        _mainCamera = Camera.main;
    }

    void Start()
    {
        playerInputActions.Enable();
        playerInputActions.Gam1.ClickEmEnemies.performed += killEm;
    }

    public void killEm(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        Debug.Log(9);
        rayHit.collider.gameObject.GetComponent<Enemy>().OnKilled();
    }
}
