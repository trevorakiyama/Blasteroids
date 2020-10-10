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


        var entities = EntityManager.GetAllEntities();

        foreach (Entity entity in entities)
        {
            var name = EntityManager.GetName(entity);

            if (name.Equals("Target"))
            {
                EntityManager.AddComponentData<Target>(entity, new Target());
                target = entity;
            }

        }

        main = Camera.main;

    }

    ProfilerMarker m1 = new ProfilerMarker("M1");

    protected override void OnUpdate()
    {

        m1.Begin();

        var m = UnityEngine.InputSystem.Mouse.current.position.ReadValue();
        var mm = main.ScreenToWorldPoint(new Vector3(m.x, m.y, 200));


        m1.End();

        // TODO:  Does this need to be cached better
        Translation playerTrans = EntityManager.GetComponentData<Translation>(PlayerSystem.playerEntity);

        float3 playerPos = playerTrans.Value;

        playerTrans.Value = (float3)mm - playerPos;

        EntityManager.SetComponentData<Translation>(target, playerTrans);

        //float3 playerPos = EntityManager.GetComponentData<Translation>(PlayerSystem.playerEntity).Value;

        //EntityManager.SetComponentData<Translation>(PlayerSystem.playerEntity, );

        ////float3 playerPos = PlayerSystem.playerPos; 


        //targetPos = mm;

        //Entities.ForEach((Entity entity, ref Translation translation, in Target targ) =>
        //{
        //    translation.Value = (float3)mm - playerPos;


        //}).Schedule();

    }
}
