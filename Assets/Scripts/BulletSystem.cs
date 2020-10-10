
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Burst;

[AlwaysUpdateSystem]
public class BulletSystem : SystemBase
{

    float lastBulletTime = 0;
    readonly float bulletDelay = .05f;

    protected override void OnUpdate()
    {
        float delta = Time.DeltaTime;

        UpdateForEach(delta);


        // Deal with collisions

       
    }

    ProfilerMarker m1 = new ProfilerMarker("m1");

    public void UpdateForEach(float delta)
    {


        float delt = delta;

       

        Entities.ForEach((Entity entity, ref Translation translation, ref Movement movement) =>
        {

            translation.Value = translation.Value + movement.velocity * delt;

        }).WithBurst().Run();

        

        EndSimulationEntityCommandBufferSystem ecbs = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        var buf = ecbs.CreateCommandBuffer().AsParallelWriter();


        m1.Begin();

        Entities.ForEach((Entity entity, int entityInQueryIndex, ref TTL ttl) =>
        {
            ttl.ttl -= delta;
            if (ttl.ttl <= 0)
            {
                buf.DestroyEntity(entityInQueryIndex, entity);
            }
        }).WithBurst().ScheduleParallel();


        ecbs.AddJobHandleForProducer(this.Dependency);

        m1.End();
    }


    public void createBullet(float3 sourcePos, Quaternion direction, float3 velocity, float ttl, Entity owner)
    {

        // TODO:  These updates need to be done at start time not update time, maybe even pooling

        EntityManager.AddComponentData<Movement>(Prefabs.bulletPrefab,
                new Movement
                {
                    velocity = velocity,
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
            Value = sourcePos
        });
        EntityManager.SetComponentData<Rotation>(newEntity, new Rotation
        {
            Value = direction
        }) ;







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

public struct Bullet : IComponentData
{
    public Entity shooter;
}
