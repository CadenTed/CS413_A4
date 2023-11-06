using Unity.Entities;
using Random = Unity.Mathematics.Random;
public struct AppleTreeProperties : IComponentData
{
    public float Speed;
    public float LeftAndRightEdge;
    public float ChangeDirectionChance;

    public Random Random;
}