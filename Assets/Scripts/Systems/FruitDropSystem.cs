
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct FruitDropSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }

    public void OnDestroy(ref SystemState state) { }

    [BurstCompile]
    public void OnUpdate(ref SystemState state) 
    {
        
        foreach (var (transform, fruitProperties) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<FruitProperties>>())
        {
            
            
            var pos = transform.ValueRO.Position;
            var speed = fruitProperties.ValueRO.speed;
            


            pos.y -= speed * SystemAPI.Time.DeltaTime;
            transform.ValueRW.Position = pos;

            
        }


    }




}


