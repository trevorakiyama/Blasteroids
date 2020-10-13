using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerShipScript : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{

    public static Entity playerShipPrefab;
    public GameObject prefabPlayerShipObject;

    //public static Vector3 position;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {

        Entity prefabEntity = conversionSystem.GetPrimaryEntity(prefabPlayerShipObject);
        playerShipPrefab = prefabEntity;

        dstManager.AddComponentData<PlayerShip>(playerShipPrefab, new PlayerShip { });
        dstManager.AddComponentData<Movement>(playerShipPrefab, new Movement { });
    }

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.Add(prefabPlayerShipObject);
    }
}
