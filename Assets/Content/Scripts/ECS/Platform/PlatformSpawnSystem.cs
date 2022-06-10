using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class PlatformSpawnSystem : IEcsInitSystem
{
    private EcsWorld _world;
    private PlatformData platformData;
    private List<EcsEntity> _entities = new List<EcsEntity>();

    public void Init()
    {
        while (PlatfromComponent.Index < 5)
        {
            EcsEntity entity = _world.NewEntity();
            ref var Component = ref entity.Get<PlatfromComponent>();
            GameObject platform = Object.Instantiate(platformData.Platform, Platform.SetPosition(platformData.Platform), Quaternion.identity);
            _entities.Add(entity);
            platform.name = "Platform " + PlatfromComponent.Index;
            Component.platform = platform;
        }
        platformData.Entityes = _entities;
    }
}
