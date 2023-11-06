using Unity.Burst;
using Unity.Entities;

[UpdateBefore(typeof(BasketMoveSystem))]
[BurstCompile]
public partial struct BasketSpawnSystem : ISystem
{
    public void OnCreate(ref SystemState state) {
    }
    public void OnDestroy(ref SystemState state) { }

    [BurstCompile]
    public void OnUpdate(ref SystemState state) {
        EntityCommandBuffer.ParallelWriter ecb = GetEntityCommandBuffer(ref state);

        new BasketSpawnerJob
        {
            ECB = ecb,
            ElapsedTime = SystemAPI.Time.ElapsedTime,
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
public partial struct BasketSpawnerJob : IJobEntity
{
    public EntityCommandBuffer.ParallelWriter ECB;
    public double ElapsedTime;
    private void Execute([ChunkIndexInQuery] int chunkIndex, ref BasketProperties basketSpawner)
    {
        if (basketSpawner.nextSpawnTime < ElapsedTime)
        {
            Entity newEntity = ECB.Instantiate(chunkIndex, basketSpawner.basketPrefab);
            basketSpawner.nextSpawnTime = (float)ElapsedTime + basketSpawner.spawnRate;
        }
    }
}