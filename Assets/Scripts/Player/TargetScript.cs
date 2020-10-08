using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public static Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Called Update for TargetScript");


        var m = UnityEngine.InputSystem.Mouse.current.position.ReadValue();
        var mm = Camera.main.ScreenToWorldPoint(new Vector3(m.x, m.y, 200));

        gameObject.transform.position = mm;

        TargetScript.position = mm;
    }
}


public struct Target : IComponentData
{

}