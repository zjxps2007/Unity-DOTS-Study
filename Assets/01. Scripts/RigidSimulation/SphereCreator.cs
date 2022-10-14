using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using TMPro;

public class SphereCreator : MonoBehaviour
{
    public GameObject spherePrefab;

    public int length;
    public int width;
    public int height;
    public TextMeshProUGUI sphereCounter;
    public Vector3 Offset;
    private int sphereCount = 0;

    private Entity sphereEntity;
    private EntityManager entityManager;
    private BlobAssetStore blobAssetStore;
    private GameObjectConversionSettings settings;
    // Start is called before the first frame update
    void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        blobAssetStore = new BlobAssetStore();
        settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobAssetStore);

        sphereEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(spherePrefab, settings);
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    //Instantiate(cubePrefab, new Vector3(l, h + 0.5f, w), Quaternion.identity);
                    Entity cube = entityManager.Instantiate(sphereEntity);
                    Translation CubeTranslation = new Translation
                    {
                        Value = new Unity.Mathematics.float3(l+Offset.x, h + 0.5f + Offset.y, w+Offset.z)
                    };
                    entityManager.SetComponentData(cube, CubeTranslation);
                    sphereCount++;
                }
            }
        }

        sphereCounter.text = "" + sphereCount*2;
    }

    private void OnDisable()
    {
        blobAssetStore.Dispose();
    }
}
