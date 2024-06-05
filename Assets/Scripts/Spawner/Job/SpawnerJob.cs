using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace SkyWalker.DOTS.Spawner.Job
{
    [BurstCompile]
    public partial struct SpawnerJob : IJobFor
    {
        [ReadOnly] public Entity Prefab;
        [ReadOnly] public float3 SpawnPosition;
        public EntityCommandBuffer.ParallelWriter ECB;

        public void Execute(int index)
        {
            Debug.Log("Spawning: " + index);
            var entity = ECB.Instantiate(index, Prefab);
            ECB.SetComponent(index, entity , new LocalTransform { Position = SpawnPosition,Scale =1});
        }
    }
}


