using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


[AlwaysUpdateSystem]
public class PlayerSystem : SystemBase
{

    public static float3 playerPos;


    // Start is called before the first frame update
    protected override void OnStartRunning()
    {
        var entities = EntityManager.GetAllEntities();

        foreach (Entity entity in entities)
        {
            var name = EntityManager.GetName(entity);

            if (name.Equals("PlayerShip"))
            {
                EntityManager.AddComponentData<PlayerShip>(entity, new PlayerShip());
            }

        }
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref Translation translation, in PlayerShip targ) =>
        {
            translation.Value += new float3(0.1f, 0, 0);
            playerPos = translation.Value;

        }).Schedule();
    }
}


public struct PlayerShip : IComponentData { }