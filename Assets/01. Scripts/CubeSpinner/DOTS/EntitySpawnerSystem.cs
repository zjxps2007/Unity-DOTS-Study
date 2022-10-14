using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class EntitySpawnerSystem : ComponentSystem
{
    private int spawnCount = 300000;
    private Random random;
    int i = 0;

    protected override void OnStartRunning()
    {
        for (i = 0; i < spawnCount; i++)
        {
            // Spawn!
            Entities.ForEach((ref PrefabEntityComponent prefabEntityComponent) =>
            {
                Entity spawnedEntity = EntityManager.Instantiate(prefabEntityComponent.prefabEntity);
                EntityManager.SetComponentData(spawnedEntity,
                    new Translation { Value = new float3(random.NextFloat(-50f, 50f), random.NextFloat(-50f, 50f), random.NextFloat(-50f, 50f)) }
                    );
            });
        }
    }
    protected override void OnCreate()
    {
        random = new Random(56);
    }

    protected override void OnUpdate()
    {
    }
}
