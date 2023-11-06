using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEditor.SceneManagement;

[BurstCompile]
public partial struct SpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state) { }

    public void OnDestroy(ref SystemState state) { }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        EntityCommandBuffer.ParallelWriter ecb = GetEntityCommandBuffer(ref state);

        new ProcessSpawnerJob
        {
            ElapsedTime = SystemAPI.Time.ElapsedTime,
            Ecb = ecb,
            LocalTransform = SystemAPI.Query<RefRW<LocalTransform>>()
        }.ScheduleParallel();

    }

    private EntityCommandBuffer.ParallelWriter GetEntityCommandBuffer(ref SystemState state)
    {
        var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();

        var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
        return ecb.AsParallelWriter();
    }

}

[BurstCompile]
public partial struct ProcessSpawnerJob : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter Ecb;
    public double ElapsedTime;
    public QueryEnumerable<RefRW<LocalTransform>> LocalTransform;

    private void Execute([ChunkIndexInQuery] int chunkIndex, ref SystemProperties spawner)
    {
        if (spawner.nextSpawnTime < ElapsedTime)
        {
            Entity newEntity = Ecb.Instantiate(chunkIndex, spawner.prefab);
            spawner.nextSpawnTime = (float)ElapsedTime + spawner.spawnRate;



        }


    }
}
