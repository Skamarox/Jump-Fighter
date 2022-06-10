using UnityEngine;
using Leopotam.Ecs;

public class EnemyAttackSystem : IEcsRunSystem
{
    private EcsFilter<Player, Health>.Exclude<Enemy> Player = null;
    private EcsFilter<Enemy, EnemyAttackComponent> Enemy = null;

    public void Run()
    {
        foreach(var i in Enemy)
        {
            if (Enemy.GetEntity(i).IsAlive() == false || Enemy.Get1(i)._Enemy == null || Player.GetEntity(0).IsAlive() == false)
                return;

            ref var PlayerObject = ref Player.Get1(i);
            ref var PlayerHealth = ref Player.Get2(i);
            ref var EnemyObject = ref Enemy.Get1(i);
            ref var EnemyAttack = ref Enemy.Get2(i);

            float Distance = Vector2.Distance(PlayerObject.player.transform.position, EnemyObject._Enemy.transform.position);
            if (Distance < EnemyAttack.AttackRange)
            {
                if (EnemyAttack.Reload == true)
                {
                    EnemyAttack.Weapon.Attack(Player.GetEntity(0));
                    EnemyAttack.Reload = false;
                }
                else
                {
                    EnemyAttack.ReloadTime -= Time.deltaTime;
                    if(EnemyAttack.ReloadTime < 0)
                    {
                        EnemyAttack.Reload = true;
                        EnemyAttack.ReloadTime = EnemyAttack.MaxReloadTime;
                    }
                }
            }
        }
    }
}
