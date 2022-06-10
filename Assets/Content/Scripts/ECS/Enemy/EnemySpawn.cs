using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class EnemySpawn : IEcsInitSystem
{
    private EcsWorld _world;
    private EnemyData _enemyData;
    private SetPositionEnemy _positionEnemy;

    public void Init()
    {
        _positionEnemy = new SetPositionEnemy();
        EventAggregator.AddListener(Create);
    }

    public void Create()
    {
        EcsEntity entity = _world.NewEntity();
        ref var MoveComponent = ref entity.Get<EnemyMoveComponent>();
        ref var SpawnComponent = ref entity.Get<EnemySpawnComponent>();
        ref var HealthComponent = ref entity.Get<Health>();
        ref var EnemyComponent = ref entity.Get<Enemy>();
        ref var EnemyAttackComponent = ref entity.Get<EnemyAttackComponent>();

        GameObject enemy = Object.Instantiate(_enemyData.Enemy, _positionEnemy.SetPosition(_enemyData.Enemy), Quaternion.identity);

        enemy.name = "enemy " + Time.time;

        MoveComponent.r2d = enemy.GetComponent<Rigidbody2D>();
        MoveComponent.PositionX = MoveComponent.r2d.position.x;
        MoveComponent.Speed = 6f;

        SpawnComponent.Offset = 0.45f;

        HealthComponent.MaxPoint = 20f;
        HealthComponent.Point = HealthComponent.MaxPoint;

        EnemyComponent._Enemy = enemy;

        EnemyAttackComponent.AttackRange = 0.5f;
        EnemyAttackComponent.Reload = true;
        EnemyAttackComponent.MaxReloadTime = 1f;
        EnemyAttackComponent.ReloadTime = EnemyAttackComponent.MaxReloadTime;
        EnemyAttackComponent.Weapon = new SimpleStick();
    }
}
