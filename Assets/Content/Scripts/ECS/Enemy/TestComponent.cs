using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public struct TestComponent
{
    private EcsWorld _world;
    private EnemyData _enemyData;
    private SetPositionEnemy _positionEnemy;

    public void Create()
    {
        if(_positionEnemy == null)
        _positionEnemy = new SetPositionEnemy();
        Debug.Log("Create");
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
        SpawnComponent.Offset = 0.45f;
        MoveComponent.Speed = 6f;
        HealthComponent.MaxPoint = 20f;
        HealthComponent.Point = HealthComponent.MaxPoint;
        EnemyComponent._Enemy = enemy;
        EnemyAttackComponent.AttackRange = 0.5f;
        EnemyAttackComponent.Damage = 5f;
    }
}