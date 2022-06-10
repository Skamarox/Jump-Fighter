using UnityEngine;
using Leopotam.Ecs;

public class BorderSystem : IEcsRunSystem, IEcsInitSystem
{
    private Transform player;
    private EcsFilter<Player> playerFilter = null;

    public void Init()
    {
        ref var p = ref playerFilter.Get1(0);
        player = p.player.transform;
    }

    public void Run()
    {
        if (playerFilter.GetEntity(0).IsAlive() == false)
            return;
        if (player.position.x > Coordinate.Max().x)
            player.position = new Vector2(Coordinate.Min().x, player.position.y);
        else
           if (player.position.x < Coordinate.Min().x)
            player.position = new Vector2(Coordinate.Max().x, player.position.y);
    }
}
