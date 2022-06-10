using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class EnemyObserver : IEcsInitSystem
{
    private float DestroyDistance = - 1.5f;
    private EcsFilter<Enemy> Enemy = null;
    private EcsFilter<Player> Player = null;

    public void Init()
    {
        EventAggregator.AddListener(RemoveEnemy);
    }

    public void RemoveEnemy() 
    {
        foreach (var i in Enemy)
        {
            ref var player = ref Player.Get1(i);
            ref var enemy = ref Enemy.Get1(i);
            float Distance = EnemyPosition.Distance(enemy._Enemy.transform.position.y, player.player.transform.position.y);
            if (Distance < DestroyDistance)
            {
                EcsEntity enemyEntity = Enemy.GetEntity(i);
                Object.Destroy(enemy._Enemy);
                enemyEntity.Destroy();
            }
        }
    }
}
