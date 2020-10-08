
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Unity.Jobs;

[AlwaysUpdateSystem]
public class BulletSystem : SystemBase
{

    float lastBulletTime = 0;
    readonly float bulletDelay = .05f;





    protected override void OnUpdate()
    {

        // TODO: The player bullet system should be separated from the generic Bullet System.

        // Just shoot a bullet every 1/10 second
        float delta = Time.DeltaTime;



        if (PlayerInputStates.IsFired())
        {
            bool newBullet = false;

            lastBulletTime += Time.DeltaTime;

            if (PlayerInputStates.newfire)
            {
                newBullet = true;
                PlayerInputStates.newfire = false;

                lastBulletTime = 0;

            } else
            {

                if (lastBulletTime > bulletDelay)
                {
                    newBullet = true;
                    lastBulletTime -= bulletDelay;
                }

            }


            if (newBullet)
            {


                Vector3 playerPos = PlayerShipScript.position;
                Vector3 targetPos = TargetScript.position;

                // Calculate rotation
                Vector3 dir = targetPos - playerPos;

                Quaternion look = Quaternion.LookRotation(dir, new Vector3(0, 0, 1));

                EntityManager.AddComponentData<Movement>(Prefabs.bulletPrefab,
                new Movement
                {
                    velocity = dir.normalized * 100,
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
            }

        }

        try
        {
            UpdateForEach(delta);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Exception" + e.ToString());



        }
    }



    public void UpdateForEach(float delta)
    {
        Entities.ForEach((Entity entity, ref Translation translation, ref Movement movement) =>
        {

            translation.Value += new float3(movement.velocity.x * delta, movement.velocity.y * delta, movement.velocity.z * delta);

        }).Schedule();


        EndSimulationEntityCommandBufferSystem ecbs = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        var buf = ecbs.CreateCommandBuffer();


        Entities.ForEach((Entity entity, ref TTL ttl) =>
        {
            ttl.ttl -= delta;
            if (ttl.ttl <= 0)
            {
                buf.DestroyEntity(entity);
            }
        }).Schedule();


        ecbs.AddJobHandleForProducer(this.Dependency);
    }

}


public struct Movement : IComponentData
{
    public float3 velocity;


    public int dummy;
}

public struct TTL : IComponentData
{
    public float ttl;
}
