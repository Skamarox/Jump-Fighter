using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        private EcsWorld _world;
        private EcsSystems _UpdateSystems;
        private EcsSystems _FixedUpdateSystems;
        public PlayerData Player;
        public PlatformData Platform;
        public EnemyData Enemy;

        void Awake () {
            _world = new EcsWorld ();
            _UpdateSystems = new EcsSystems (_world);
            _FixedUpdateSystems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_UpdateSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_FixedUpdateSystems);
#endif
            _UpdateSystems
                .ConvertScene()
                .OneFrame<JumpEvent>()
                .OneFrame<PlayerAttackEvent>()
                .OneFrame<PlatformEvent>()

                .Add(new JumpSystem())
                .Add(new PlatformSpawnSystem())
                .Add(new PlayerSpawn())
                .Add(new AttackSystem())
                .Add(new BorderSystem())
                .Add(new PlatformObserver())
                .Add(new EnemyAttackSystem())
                .Add(new EnemyObserver())
                .Add(new EnemySpawn())
                .Add(new GetDamagePlayer())
                .Add(new EnemyGetDamage())
                .Inject(Player)
                .Inject(Platform)
                .Inject(Enemy)
                .Init ();

            _FixedUpdateSystems
                .Add(new MoveSystem())
                .Add(new EnemyMoveSystem())
                .Init();
        }

        void Update () {
            _UpdateSystems?.Run ();
        }

        private void FixedUpdate()
        {
            _FixedUpdateSystems?.Run();
        }

        void OnDestroy () {
                _UpdateSystems?.Destroy ();
                _UpdateSystems = null;
                _FixedUpdateSystems?.Destroy();
                _FixedUpdateSystems = null;
                _world?.Destroy ();
                _world = null;
        }
    }
}