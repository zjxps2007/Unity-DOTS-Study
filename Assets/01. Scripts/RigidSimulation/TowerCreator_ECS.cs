using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using TMPro;

public class TowerCreator_ECS : MonoBehaviour
{
    public GameObject cubePrefab;

    public int length;
    public int width;
    public int height;
    public TextMeshProUGUI cubeCounter;

    private int cubeCount = 0;

    private Entity cubeEntity;
    private EntityManager entityManager;
    private BlobAssetStore blobAssetStore;
    private GameObjectConversionSettings settings;
    // Start is called before the first frame update
    void Start()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        blobAssetStore = new BlobAssetStore();
        settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobAssetStore);

        cubeEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(cubePrefab, settings);
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {

                    if (l != 0 && w != 0 && l != length - 1 && w != width - 1)
                    {
                        continue;
                    }
                    //Instantiate(cubePrefab, new Vector3(l, h + 0.5f, w), Quaternion.identity);
                    Entity cube = entityManager.Instantiate(cubeEntity);
                    Translation CubeTranslation = new Translation
                    {
                        Value = new Unity.Mathematics.float3(l, h + 0.5f, w)
                    };
                    entityManager.SetComponentData(cube, CubeTranslation);
                    cubeCount++;
                }
            }
        }

        cubeCounter.text = "" + cubeCount;
    }

    private void OnDisable()
    {
        blobAssetStore.Dispose();
    }
}
