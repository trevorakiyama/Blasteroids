
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Burst;
using UnityEngine;
using Unity.Collections;

using Random = Unity.Mathematics.Random;

[AlwaysUpdateSystem]
public class BulletSystem : SystemBase
{

    Random rand = new Random(5);

    EndSimulationEntityCommandBufferSystem ecbs;


    protected override void OnStartRunning()
    {
        ecbs = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }



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

        

        //EndSimulationEntityCommandBufferSystem ecbs = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
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


    public void createBullet(float3 sourcePos, Quaternion direction, float3 _velocity, float ttl, Entity owner)
    {


        ProfilerMarker m1 = new ProfilerMarker("CreateBullet");

        Entity newEntity = EntityManager.Instantiate(Prefabs.bulletPrefab);

        EntityManager.SetComponentData<Movement>(newEntity,
               new Movement
               {
                   velocity = _velocity,
                   dummy = 10
               });

        EntityManager.AddComponentData<TTL>(newEntity,
                new TTL
                {
                    ttl = 2
                });



        EntityManager.SetComponentData<Translation>(newEntity, new Translation
        {
            Value = sourcePos
        });
        EntityManager.SetComponentData<Rotation>(newEntity, new Rotation
        {
            Value = direction
        }) ;


        var buf = ecbs.CreateCommandBuffer();

        m1.Begin();

        NativeArray<Random> randArr = new NativeArray<Random>(1, Allocator.TempJob);
        randArr[0] = rand;


        var handle = new InitializeBullets()
        {
            randomArray = randArr,
            bulletPrefab = Prefabs.bulletPrefab,
            commandBuffer = buf,
            bulletArchetype = Prefabs.bulletArchetype

        }.Schedule();

        handle.Complete();

        rand = randArr[0];

        ecbs.AddJobHandleForProducer(this.Dependency);

        randArr.Dispose();

        m1.End();
    }


}


[BurstCompile]
public struct InitializeBullets : IJob
{
    public NativeArray<Unity.Mathematics.Random> randomArray;
    public Entity bulletPrefab;
    //public float3 source;
    //public Quaternion direction;
    //public float3 velocity;
    //public float ttl;
    //public Entity owner;
    //public float spread;
    //public int number;
    public EntityCommandBuffer commandBuffer;
    public EntityArchetype bulletArchetype;

    public void Execute()
    {

        Random random = randomArray[0];

        for (int i = 0; i < 20; i++)
        {
            Entity newEntity = commandBuffer.Instantiate(bulletPrefab);
            commandBuffer.SetComponent<Translation>(newEntity, new Translation { Value = new float3(-100 + 2 * i, -100, 0) });
            commandBuffer.SetComponent<Movement>(newEntity, new Movement { velocity = new float3(random.NextFloat(-100, 100), 100, 0) });

        }

        randomArray[0] = random;
      
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
