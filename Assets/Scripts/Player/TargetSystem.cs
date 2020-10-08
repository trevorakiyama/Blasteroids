using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[AlwaysUpdateSystem]
public class TargetSystem : SystemBase
{
    public static float3 targetPos;

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
            }

        }
    }



    protected override void OnUpdate()
    {

        var m = UnityEngine.InputSystem.Mouse.current.position.ReadValue();
        var mm = Camera.main.ScreenToWorldPoint(new Vector3(m.x, m.y, 200));

        float3 playerPos = PlayerSystem.playerPos; 


        targetPos = mm;

        Entities.ForEach((Entity entity, ref Translation translation, in Target targ) =>
        {
            translation.Value = (float3)mm - playerPos;


        }).Schedule();

    }
}
