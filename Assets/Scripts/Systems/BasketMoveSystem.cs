using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;
using Unity.Mathematics;
using System.Numerics;
using UnityEngine;

[BurstCompile]
public partial struct BasketMoveSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }

    public void OnDestroy(ref SystemState state) { }

    [BurstCompile]
    public void OnUpdate(ref SystemState state) 
    {
        foreach( var (propeties, transform) in SystemAPI.Query<RefRW<BasketMoveProperties>, RefRW<LocalTransform>>())
        {
            var pos = transform.ValueRO.Position;

            pos.y = -10;
            transform.ValueRW.Position = pos;


            float3 mousePos2D = Input.mousePosition;

            mousePos2D.z = -Camera.main.transform.position.z;

            float3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );

            pos.x = mousePos3D.x;
            transform.ValueRW.Position = pos;
        }
    }
}