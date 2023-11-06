using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;

    public class SystemAuthoring : MonoBehaviour
    {
        public GameObject prefab;
        public float spawnRate;
        //public float3 spawnPos = new float3(1, 1, 1);
        private class SystemAuthoringBaker : Baker<SystemAuthoring>
        {
            public override void Bake(SystemAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                
                AddComponent(entity, new SystemProperties
                {
                    prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
                    nextSpawnTime = 0.0f,
                    spawnRate = authoring.spawnRate,
                    spawnPos = authoring.transform.position
                });
            }
        }
    }
