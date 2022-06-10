using Leopotam.Ecs;

public struct EnemyAttackComponent 
{
    public IEnemyWeapon Weapon;
    public float Damage;
    public float AttackRange;
    public bool Reload;
    public float ReloadTime;
    public float MaxReloadTime;
}
