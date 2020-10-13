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

                Vector3 playerPos = entityManager.GetComponentData<Translation>(PlayerSystem.playerEntity).Value;
                Vector3 targetPos = entityManager.GetComponentData<Translation>(TargetSystem.target).Value;  // rel to player






                FireSpread(entityManager, playerPos, targetPos - playerPos, 1, 1);



            }

        }
    }


    private void FireSpread(EntityManager entityManager, float3 source, float3 direction, int number, float spread)
    {


        float bulletSpeed = Settings._bulletSpeed;
        float ttl = 2;



        Vector3 dir = direction;
        float3 velocity = dir.normalized * bulletSpeed;
        Quaternion look = Quaternion.LookRotation(dir);
        Debug.DrawRay(source, dir * 100, Color.white, 0.5f);



        BulletSystem bulletSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<BulletSystem>();
        bulletSystem.createBullet(source, look, velocity, ttl, PlayerSystem.playerEntity);




    }


    private void Fire(EntityManager entityManager, float3 source, float3 direction)
    {


        float bulletSpeed = Settings._bulletSpeed;
        float ttl = 2;

        //Vector3 playerPos = entityManager.GetComponentData<Translation>(PlayerSystem.playerEntity).Value;
        //Vector3 playerMovement = entityManager.GetComponentData<Movement>(PlayerSystem.playerEntity).velocity;
        //Vector3 targetPos = entityManager.GetComponentData<Translation>(TargetSystem.target).Value;  // rel to player



        Vector3 dir = direction;
        float3 velocity = dir.normalized * bulletSpeed;
        Quaternion look = Quaternion.LookRotation(dir);
        Debug.DrawRay(source, dir * 100, Color.white, 0.5f);


        BulletSystem bulletSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<BulletSystem>();
        bulletSystem.createBullet(source, look, velocity, ttl, PlayerSystem.playerEntity);

    }





}
