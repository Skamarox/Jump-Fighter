using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class GetDamagePlayer : IEcsRunSystem
{
    private EcsFilter<Player, Health>.Exclude<Enemy> player = null;

    public void Run()
    {
        if (player.Get1(0).player == null || player.GetEntity(0).IsAlive() == false)
            return;

        if(player.Get2(0).Point <= 0)
        {
            EcsEntity Player = player.GetEntity(0);
            Object.Destroy(player.Get1(0).player);
            Player.Destroy();
        }
    }
}
