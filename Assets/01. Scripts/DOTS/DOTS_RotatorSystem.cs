#if TRUE
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public struct DOTS_RotatorData : IComponentData
{
    public float _speed;
}
public class DOTS_RotatorSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var dt = Time.DeltaTime;

        Entities.ForEach((ref DOTS_RotatorData rotator, ref Rotation rotation) =>
        {
            rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(math.up(), rotator._speed * dt));
        });
    }
}
#endif