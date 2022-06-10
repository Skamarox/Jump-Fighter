using UnityEngine;
using Leopotam.Ecs;

public class MagicStick : IWeapon
{
    private float Damage = 6.5f;

    public void Attack(EcsEntity entity)
    {
        entity.Get<Health>().Point -= Damage;
        Debug.Log(entity.Get<Health>().Point);
    }
}
