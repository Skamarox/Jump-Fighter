using Leopotam.Ecs;
using UnityEngine;

public class MoveSystem : IEcsRunSystem
{
    private EcsFilter<MoveComponent> move = null;

    public void Run()
    {
        if (Input.GetKey(KeyCode.A))
            Moving(Vector2.left);

        if (Input.GetKey(KeyCode.D))
            Moving(Vector2.right);
    }

    private void Moving(Vector2 direction)
    {
        ref var m = ref move.Get1(0);
        m.r2d.AddForce(direction * m.Speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}
