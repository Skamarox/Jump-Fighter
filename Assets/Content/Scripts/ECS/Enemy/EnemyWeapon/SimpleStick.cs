using Leopotam.Ecs;
public class SimpleStick : IEnemyWeapon
{
    private float Damage = 1f;

    public void Attack(EcsEntity entity)
    {
        UnityEngine.Debug.Log($"Simple stick take damage on player is {Damage}");
        entity.Get<Health>().Point -= Damage;
    }
}
