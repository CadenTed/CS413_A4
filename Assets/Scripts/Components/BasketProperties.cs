using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct BasketProperties : IComponentData
{
    public float basketOffset;
    public Entity basketPrefab;
    public float3 spawnPos;
    public float numBaskets;
    public float basketBottomY;
    public float nextSpawnTime;
    public float spawnRate;
}