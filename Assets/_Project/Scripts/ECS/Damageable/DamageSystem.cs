using Assets._Project.Scripts.ECS.Health;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Systems;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets._Project.Scripts.ECS.Damageable
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DamageSystem))]
    public sealed class DamageSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<HealthComponent>().
                With<Damage>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref HealthComponent health = ref entity.GetComponent<HealthComponent>();
                ref Damage damage = ref entity.GetComponent<Damage>();

                if (damage.Value == 0)
                    continue;

                health.Value =  Mathf.Max( health.Value - damage.Value,0);
                entity.RemoveComponent<Damage>();

                if (health.Value <= 0)
                    entity.Dispose();
            }
        }
    }
}
