using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BasketMoveAuthoring : MonoBehaviour
{
    public float funNumber;

    private class BasketMoveBaker : Baker<BasketMoveAuthoring>
    {
        public override void Bake(BasketMoveAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new BasketMoveProperties
            { 
                funNumber = authoring.funNumber
            });

        }
    }
}