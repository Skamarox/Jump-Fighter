using UnityEngine;
using Leopotam.Ecs;

public class PlatformObserver : IEcsRunSystem, IEcsInitSystem
{
    private float DestroyDistance = 2;
    private EcsFilter<Player> playerFilter = null;
    private PlatformData platformData;
    private GameObject player;

    public void Init()
    {
        ref var _palyer = ref playerFilter.Get1(0);
        player = _palyer.player;
    }

    public void Run()
    {
        foreach (EcsEntity entity in platformData.Entityes)
        {
            if (playerFilter.GetEntity(0).IsAlive() == false)
                return;

            GameObject platform = entity.Get<PlatfromComponent>().platform;
            float Distance = Platform.Distance(player.transform.position.y, platform.transform.position.y);

            if (Distance > DestroyDistance)
            {
                platform.transform.position = Platform.SetPosition(platformData.Platform);

                EventAggregator.Invoke();
            }

            entity.Get<PlatformEvent>();
        }
    }
}
