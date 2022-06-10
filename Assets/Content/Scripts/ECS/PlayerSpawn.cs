using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class PlayerSpawn : IEcsInitSystem
{
    private EcsWorld _world;
    private PlayerData Data;
    private float JumpForce = 4.5f;
    private float Speed = 8f;

    public void Init()
    {
        EcsEntity playerEntity = _world.NewEntity();
        ref var Jump_player = ref playerEntity.Get<JumpComponent>();
        ref var Move_Player = ref playerEntity.Get<MoveComponent>();
        ref var Attack_Player = ref playerEntity.Get<WeaponComponent>();
        ref var PlayerComponent = ref playerEntity.Get<Player>();
        ref var Health_Component = ref playerEntity.Get<Health>();
        GameObject player = Object.Instantiate(Data.Player, Data.Player.transform.position, Quaternion.identity);

        Jump_player.r2d = player.GetComponent<Rigidbody2D>();
        Jump_player.JumpForce = JumpForce;
        Move_Player.r2d = player.GetComponent<Rigidbody2D>();
        Move_Player.Speed = Speed;
        PlayerComponent.player = player;
        Attack_Player.weapon = new Sword();
        Health_Component.MaxPoint = 50f;
        Health_Component.Point = Health_Component.MaxPoint;
    }
}
