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

        playerEntity = EntityManager.Instantiate(PlayerShipScript.playerShipPrefab);

        playerFire = new PlayerFiring();

    }




    // Update is called once per frame
    protected override void OnUpdate()
    {
        playerFire.HandlePlayerFiring(EntityManager, Time.DeltaTime);
        HandleMovement();
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


            float movementSpeed = Settings._movementSpeed;


            //float3 pos = new float3(0, 0, 0);
            var delta = Time.DeltaTime;

            Entities.ForEach((Entity entity, ref Translation translation, ref Movement movement, in PlayerShip targ) =>
            {
                movement.velocity = newMovement * (delta * movementSpeed);

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