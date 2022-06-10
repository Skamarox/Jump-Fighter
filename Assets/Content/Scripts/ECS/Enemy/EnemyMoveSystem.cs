using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class EnemyMoveSystem : IEcsRunSystem
{
    private EcsFilter<EnemyMoveComponent, EnemySpawnComponent, Enemy> Enemy = null;

    public void Run()
    {
        foreach(var i in Enemy)
        {
            if (Enemy.Get3(i)._Enemy == null || Enemy.GetEntity(i).IsAlive() == false)
                return;

            ref var move = ref Enemy.Get1(i);
            ref var spawn = ref Enemy.Get2(i);
            float leftBorder = move.PositionX - spawn.Offset;
            float rightBorder = move.PositionX + spawn.Offset;

            if (move.r2d.position.x >= rightBorder)
                move.right = false;
            if (move.r2d.position.x <= leftBorder)
                move.right = true;

            switch(move.right)
            {
                case true:
                    move.r2d.AddForce(Vector2.right * move.Speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                    break;
                case false:
                    move.r2d.AddForce(Vector2.left * move.Speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
                    break;
            }
        }
    }
}
