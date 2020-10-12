using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;


public class Prefabs : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public static Entity bulletPrefab;
    public GameObject prefabBulletObject;



    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

        Entity prefabEntity = conversionSystem.GetPrimaryEntity(prefabBulletObject);
        bulletPrefab = prefabEntity;

        dstManager.AddComponentData<Movement>(bulletPrefab, new Movement
        {
            velocity = 100,
            dummy = 0
        });

        dstManager.AddComponentData<TTL>(bulletPrefab, new TTL
        {
            ttl = 2
        });

    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(prefabBulletObject);
    }
}
