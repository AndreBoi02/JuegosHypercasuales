using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ClickEm : MonoBehaviour
{
    //Saqué este código de un video de Youtube: https://www.youtube.com/watch?v=mRkFj8J7y_I y le hice mis propias modificaciones

    private PlayerInputActions playerInputActions;
    private Camera _mainCamera;
    [SerializeField] private TMP_Text text;
    public float points = 0;

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

        rayHit.collider.gameObject.GetComponent<Enemy>().OnKilled();
        text.text = "Points: " + points;
    }
}
