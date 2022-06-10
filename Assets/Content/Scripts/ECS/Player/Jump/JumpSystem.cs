using UnityEngine;
using Leopotam.Ecs;
using System.Threading.Tasks;

public class JumpSystem : IEcsRunSystem
{
    private EcsFilter <Player, JumpComponent> _filter = null;
    private bool isJump = false;
    private int TimerMilliseconds = 280;

    public void Run()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump == true) return;

            ref var entity = ref _filter.GetEntity(0);
            entity.Get<JumpEvent>();
            ref var comp = ref _filter.Get2(0);
            Jump(comp.r2d, comp.JumpForce);
        }
    }

    async private void Jump(Rigidbody2D r2d, float Force) 
    {
        isJump = true;
        r2d.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
        await Task.Delay(TimerMilliseconds);
        isJump = false;
    }
}
