using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class FruitAuthoring : MonoBehaviour
{
    public float speed;

    private class FruitBaker : Baker<FruitAuthoring>
    {
        public override void Bake(FruitAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new FruitProperties
            {
                speed = authoring.speed
            });

        }
    }
}


