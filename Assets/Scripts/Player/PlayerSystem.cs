using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


[AlwaysUpdateSystem]
public class PlayerSystem : SystemBase
{

    //public static float3 playerPos;

    public static Entity playerEntity;

    public static PlayerFiring playerFire;


    public static float thrust = 30;


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
                EntityManager.AddComponentData<Movement>(entity, new Movement() { velocity = new float3(0, 0, 0) });
                EntityManager.AddComponentData<Bullet>(entity, new Bullet() { shooter = entity });
                playerEntity = entity;
            }
        }

        playerFire = new PlayerFiring();

    }




    // Update is called once per frame
    protected override void OnUpdate()
    {
        playerFire.HandlePlayerFiring(EntityManager, Time.DeltaTime);
        HandleMovement();
    }


    // TODO:  Should the player firing go to another Class or system?
    float lastBulletTime = 0;
    float bulletDelay = 0.1f;

    protected void HandlePlayerFiring(BulletSystem bulletSystem)
    {

        if (PlayerInputStates.fire == true)
        {
            bool newBullet = false;

            lastBulletTime += Time.DeltaTime;

            if (PlayerInputStates.newfire)
            {
                newBullet = true;
                PlayerInputStates.newfire = false;

                lastBulletTime = 0;

            }
            else
            {
                if (lastBulletTime > bulletDelay)
                {
                    newBullet = true;
                    lastBulletTime -= bulletDelay;
                }
            }


            if (newBullet)
            {

                float ttl = 2;
                // TODO Make this call objects or even entity managers.
                Vector3 playerPos = EntityManager.GetComponentData<Translation>(PlayerSystem.playerEntity).Value;
                Vector3 playerMovement = EntityManager.GetComponentData<Movement>(PlayerSystem.playerEntity).velocity;
                Vector3 targetPos = EntityManager.GetComponentData<Translation>(TargetSystem.target).Value;
                //Vector3 targetPos = TargetSystem.targetPos; // TargetScript.position;

                // Calculate rotation
                Vector3 dir = targetPos - playerPos;

                Quaternion look = Quaternion.LookRotation(dir, new Vector3(0, 0, 1));

                float3 velocity = dir.normalized * 100 + playerMovement;

                bulletSystem.createBullet(playerPos, look, velocity, ttl, PlayerSystem.playerEntity);


                /*
                EntityManager.AddComponentData<Movement>(Prefabs.bulletPrefab,
                new Movement
                {
                    velocity = dir.normalized * 100 + playerMovement,
                    dummy = 10
                });

                EntityManager.AddComponentData<TTL>(Prefabs.bulletPrefab,
                new TTL
                {
                    ttl = 2
                });


                Entity newEntity = EntityManager.Instantiate(Prefabs.bulletPrefab);
                EntityManager.SetComponentData<Translation>(newEntity, new Translation
                {
                    Value = playerPos
                });
                EntityManager.SetComponentData<Rotation>(newEntity, new Rotation
                {
                    Value = look
                });

                */
            }

        }
    }



    protected void HandleMovement()
    {
        // check if any controls are pressed and determine the vector for accelleration
        float3 newMovement = new float3(0, 0, 0);
        if (PlayerInputStates.moveUp == true)
        {
            newMovement.y += 1;
        }
        if (PlayerInputStates.moveDown == true)
        {
            newMovement.y -= 1;
        }
        if (PlayerInputStates.moveRight == true)
        {
            newMovement.x += 1;
        }
        if (PlayerInputStates.moveLeft == true)
        {
            newMovement.x -= 1;
        }

        float total = newMovement.x * newMovement.x + newMovement.y * newMovement.y;

        if (total > 0)
        {
            if (total > 1)
            {
                newMovement.x = newMovement.x * 0.707f;
                newMovement.y = newMovement.y * 0.707f;
            }

            newMovement *= thrust;

            //float3 pos = new float3(0, 0, 0);
            var delta = Time.DeltaTime;

            Entities.ForEach((Entity entity, ref Translation translation, ref Movement movement, in PlayerShip targ) =>
            {
                movement.velocity = newMovement * delta * 200;

            }).WithBurst().Run();
        } else
        {
            var delta = Time.DeltaTime;
            // TODO:  Should this just call Entity manager?
            //float3 pos = new float3(0, 0, 0);
            Entities.ForEach((Entity entity, ref Translation translation, ref Movement movement, in PlayerShip targ) =>
            {

                movement.velocity = new float3(0, 0, 0);

                //movement.velocity -= movement.velocity * 0.5f * delta;

            }).WithBurst().Run();


        }
    }

}









public struct PlayerShip : IComponentData { }