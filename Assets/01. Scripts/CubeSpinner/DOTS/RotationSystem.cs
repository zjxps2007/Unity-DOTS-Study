using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public partial class RotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        
        Entities.ForEach((ref Rotation rotation, in RotationSpeed rotationSpeed) => {
            rotation.Value = math.mul(rotation.Value, quaternion.RotateY(rotationSpeed.rotateSpeed * deltaTime));
        }).Schedule();
    }
}
