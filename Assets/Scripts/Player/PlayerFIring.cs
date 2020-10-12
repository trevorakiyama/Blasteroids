using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerFiring
{

    float lastBulletTime = 0;
    float bulletDelay = 0.1f;


    public void HandlePlayerFiring(EntityManager entityManager, float deltaTime)
    {


        if (PlayerInputStates.fire == true)
        {
            bool newBullet = false;

            lastBulletTime += deltaTime;

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

                // TODO Make this call objects or even entity managers.
                Vector3 playerPos = entityManager.GetComponentData<Translation>(PlayerSystem.playerEntity).Value;
                Vector3 playerMovement = entityManager.GetComponentData<Movement>(PlayerSystem.playerEntity).velocity;
                Vector3 targetPos = entityManager.GetComponentData<Translation>(TargetSystem.target).Value;

                //Vector3 targetPos = TargetSystem.targetPos; // TargetScript.position;

                // Calculate rotation
                Vector3 dir = targetPos;

                Quaternion look = Quaternion.LookRotation( dir);

                Debug.DrawRay(playerPos, dir * 100, Color.white, 0.5f);

                float3 velocity = dir.normalized * Settings._bulletSpeed;

                // TODO: Make this configurable
                float ttl = 2;


                BulletSystem bulletSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<BulletSystem>();

                bulletSystem.createBullet(playerPos, look, velocity, ttl, PlayerSystem.playerEntity);

            }

        }
    }


    private void Fire(EntityManager entityManager)
    {


        float bulletSpeed = Settings._bulletSpeed;
        float ttl = 2;

        Vector3 playerPos = entityManager.GetComponentData<Translation>(PlayerSystem.playerEntity).Value;
        Vector3 playerMovement = entityManager.GetComponentData<Movement>(PlayerSystem.playerEntity).velocity;
        Vector3 targetPos = entityManager.GetComponentData<Translation>(TargetSystem.target).Value;  // rel to player



        Vector3 dir = targetPos;
        float3 velocity = dir.normalized * bulletSpeed;
        Quaternion look = Quaternion.LookRotation(dir);
        Debug.DrawRay(playerPos, dir * 100, Color.white, 0.5f);


        BulletSystem bulletSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<BulletSystem>();
        bulletSystem.createBullet(playerPos, look, velocity, ttl, PlayerSystem.playerEntity);

    }





}
