using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Enemy;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Providers;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets._Project.Scripts.ECS.Player
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]

    [RequireComponent(typeof(Collider))]
    public sealed class PlayerProvider : MonoProvider<PlayerMarker>
    {
        protected override void Deinitialize()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            if (Entity.IsDisposed())
                Destroy(gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out EnemyProvider enemyProvider))
            {
                if (enemyProvider.Entity.Has<Damage>())
                {
                    ref Damage damage = ref enemyProvider.Entity.GetComponent<Damage>();

                    if (damage.IsReadyAttack == false)
                        return;

                    ref Damagable damagable = ref Entity.GetComponent<Damagable>();

                    damagable.Value += damage.Value;
                    damage.IsReadyAttack = false;
                }
            }
        }
    }
}
