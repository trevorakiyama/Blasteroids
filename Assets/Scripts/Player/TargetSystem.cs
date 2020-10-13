using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;

[AlwaysUpdateSystem]
public class TargetSystem : SystemBase
{
    //public static float3 targetPos;
    public static Camera main;

    public static Entity target;


    protected override void OnStartRunning()
    {

        //base.OnStartRunning();
        Debug.Log("START");


        target = EntityManager.Instantiate(TargetScript.targetPrefab);        

        main = Camera.main;

    }

    protected override void OnUpdate()
    {
        var m = UnityEngine.InputSystem.Mouse.current.position.ReadValue();
        var mm = main.ScreenToWorldPoint(new Vector3(m.x, m.y, 200));

        // TODO:  Does this need to be cached better
        Translation playerTrans = EntityManager.GetComponentData<Translation>(PlayerSystem.playerEntity);

        float3 playerPos = playerTrans.Value;

        playerTrans.Value = (float3)mm;

        EntityManager.SetComponentData<Translation>(target, playerTrans);

    }
}
