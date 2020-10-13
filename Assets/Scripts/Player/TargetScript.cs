using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class TargetScript : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{

    public static Entity targetPrefab;
    public GameObject prefabTargetObject;

    public static Vector3 position;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

        Entity prefabEntity = conversionSystem.GetPrimaryEntity(prefabTargetObject);
        targetPrefab = prefabEntity;

        dstManager.AddComponentData<Target>(targetPrefab, new Target {});
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(prefabTargetObject);
    }
}


public struct Target : IComponentData
{

}