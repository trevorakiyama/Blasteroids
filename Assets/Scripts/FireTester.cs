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

    }

    private void OnDisable()
    {
        _controls.PlayerShip.Fire.performed -= HandleFire;
    }

    private void HandleFire(InputAction.CallbackContext context)
    {

        var started =context.started;
        var startTime = context.startTime;
        var time = context.time;
        var phase = context.phase;

        Debug.Log($"Fire {started} {startTime} {time} {phase}");



        // Simple Test
        // Fire a single bullet from the player ship



        PlayerInputStates.Fire();

    }

    private void HandleNoFire(InputAction.CallbackContext context)
    {

        

        var started = context.started;
        var startTime = context.startTime;
        var time = context.time;
        var phase = context.phase;

        Debug.Log($"Fire {started} {startTime} {time} {phase}");
    }









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
