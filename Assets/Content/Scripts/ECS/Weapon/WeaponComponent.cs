using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public interface IWeapon
{
    void Attack(EcsEntity entity);
}

public struct WeaponComponent 
{
    public IWeapon weapon;
}
