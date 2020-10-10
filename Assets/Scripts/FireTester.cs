using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireTester : MonoBehaviour
{

    [SerializeField] private PlayerControls _controls;
    [SerializeField] private int testInt;



    private void Awake()
    {
        _controls = new PlayerControls();

    }

    private void OnEnable()
    {

        Debug.Log("OnEnable");

        _controls.PlayerShip.Fire.performed += HandleFire;
        _controls.PlayerShip.Fire.canceled += HandleNoFire;
        _controls.PlayerShip.Fire.Enable();


        _controls.PlayerShip.Exit.performed += HandleExit;
        _controls.PlayerShip.Exit.Enable();


        _controls.PlayerShip.MoveUp.performed += HandleUp;
        _controls.PlayerShip.MoveUp.canceled += HandleNoUp;
        _controls.PlayerShip.MoveUp.Enable();

        _controls.PlayerShip.MoveDown.performed += HandleDown;
        _controls.PlayerShip.MoveDown.canceled += HandleNoDown;
        _controls.PlayerShip.MoveDown.Enable();

        _controls.PlayerShip.MoveRight.performed += HandleRight;
        _controls.PlayerShip.MoveRight.canceled += HandleNoRight;
        _controls.PlayerShip.MoveRight.Enable();

        _controls.PlayerShip.MoveLeft.performed += HandleLeft;
        _controls.PlayerShip.MoveLeft.canceled += HandleNoLeft;
        _controls.PlayerShip.MoveLeft.Enable();








    }

    private void OnDisable()
    {
        _controls.PlayerShip.Fire.performed -= HandleFire;
    }

    private void HandleFire(InputAction.CallbackContext context)
    {
        PlayerInputStates.Fire();
    }

    private void HandleNoFire(InputAction.CallbackContext context)
    {
        PlayerInputStates.ResetFire();
    }




    private void HandleUp(InputAction.CallbackContext context) {
        PlayerInputStates.moveUp = true; }
    private void HandleNoUp(InputAction.CallbackContext context) { PlayerInputStates.moveUp = false; }


    private void HandleDown(InputAction.CallbackContext context) { PlayerInputStates.moveDown = true; }
    private void HandleNoDown(InputAction.CallbackContext context) { PlayerInputStates.moveDown = false; }


    private void HandleRight(InputAction.CallbackContext context) { PlayerInputStates.moveRight = true; }
    private void HandleNoRight(InputAction.CallbackContext context) { PlayerInputStates.moveRight = false; }

    private void HandleLeft(InputAction.CallbackContext context) { PlayerInputStates.moveLeft = true; }
    private void HandleNoLeft(InputAction.CallbackContext context) { PlayerInputStates.moveLeft = false; }





    private void HandleExit(InputAction.CallbackContext context)
    {
        Debug.Log("Exit");
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif

    }

}
