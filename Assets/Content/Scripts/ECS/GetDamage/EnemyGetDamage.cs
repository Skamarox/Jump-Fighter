using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class EnemyGetDamage : IEcsRunSystem
{
    private EcsFilter<Enemy, Health>.Exclude<Player> enemy = null;

    public void Run()
    {
        foreach(var i in enemy) 
        {
            if (enemy.Get1(i)._Enemy == null || enemy.GetEntity(i).IsAlive() == false)
                return;

            Debug.Log("Enemy point is " + enemy.Get2(i).Point);
            if (enemy.Get2(i).Point <= 0)
            {
                EcsEntity Enemy = enemy.GetEntity(i);
                Object.Destroy(enemy.Get1(i)._Enemy);
                Enemy.Destroy();
            }
        }
    }
}
