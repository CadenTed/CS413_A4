
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BasketAuthoring : MonoBehaviour
{
    public float basketOffset;
    public GameObject basket;
    public float numBaskets;
    public float basketBottomY;
    public float3 spawnPos;
    public float spawnRate;

    private class BasketBaker : Baker<BasketAuthoring>
    {
        public override void Bake(BasketAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            var properies = new BasketProperties
            {
                basketPrefab = GetEntity(authoring.basket, TransformUsageFlags.Dynamic),
                basketOffset = authoring.basketOffset,
                spawnPos = authoring.spawnPos,
                spawnRate = authoring.spawnRate,
                nextSpawnTime = 0.0f
            };

            AddComponent(entity, properies);
        }
    }
}