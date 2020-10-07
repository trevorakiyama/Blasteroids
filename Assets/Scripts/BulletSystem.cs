
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Unity.Jobs;

[AlwaysUpdateSystem]
public class BulletSystem : SystemBase
{

    float lastBulletTime = 0;





    protected override void OnUpdate()
    {
        // Just shoot a bullet every 1/10 second
        float delta = Time.DeltaTime;
        double elapsed = Time.ElapsedTime;



        if (PlayerInputStates.IsFired())
        {

            PlayerInputStates.ResetFire();

            Vector3 playerPos = PlayerShipScript.position;

            EntityManager.AddComponentData<Movement>(Prefabs.bulletPrefab,
            new Movement
            {
                velocity = new float3(0, 50, 0),
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

            translation.Value = translation.Value + new float3(movement.velocity.x * delta, movement.velocity.y * delta, movement.velocity.z * delta);

        }).Schedule();


        EndSimulationEntityCommandBufferSystem ecbs = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        var buf = ecbs.CreateCommandBuffer();


        Entities.ForEach((Entity entity, ref TTL ttl) =>
        {
            ttl.ttl = ttl.ttl - delta;
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
