using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class AttackSystem : IEcsRunSystem
{
    private EcsFilter<Player, WeaponComponent> Player = null;
    private EcsFilter<Enemy, Health> Enemy = null;

    public void Run()
    {
        foreach (var i in Player)
        {
            if (Player.Get1(i).player == null || Player.GetEntity(i).IsAlive() == false)
                return;
            foreach (var j in Enemy)
            {
                if (Enemy.Get1(j)._Enemy == null || Enemy.GetEntity(j).IsAlive() == false)
                    return;

                ref var PlayerObject = ref Player.Get1(i);
                ref var WeaponComponent = ref Player.Get2(i);
                ref var EnemyObject = ref Enemy.Get1(j);
                ref var EnemyHealth = ref Enemy.Get2(j);

                if (Input.GetMouseButtonDown(0))
                {
                    float Distance = Vector2.Distance(PlayerObject.player.transform.position, EnemyObject._Enemy.transform.position);
                    if (Distance < 0.5f)
                        WeaponComponent.weapon.Attack(Enemy.GetEntity(j));
                }
                ref var entity = ref Player.GetEntity(i);
                entity.Get<PlayerAttackEvent>();
            }
        }
    }
}
