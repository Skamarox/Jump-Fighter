using Leopotam.Ecs;

public class Sword : IWeapon
{
    private float Damage = 5f;
    public void Attack(EcsEntity entity)
    {
        entity.Get<Health>().Point -= Damage;
        UnityEngine.Debug.Log(entity.Get<Health>().Point);
    }
}
