using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Health;
using Assets._Project.Scripts.ECS.Player;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using AttackComponent = Assets._Project.Scripts.ECS.Attack.Attack;

namespace Assets._Project.Scripts.ECS.Enemy
{
    public class EnemyProvider : MonoProvider<EnemyMarker>
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerProvider entityProvider))
            {
                if (entityProvider.Entity.IsDisposed())
                    return;

                if (entityProvider.Entity.Has<HealthComponent>() == false)
                    return;

                ref AttackComponent attack = ref Entity.GetComponent<AttackComponent>();

                attack.Target = entityProvider.Entity;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerProvider entityProvider))
            {
                ref AttackComponent attack = ref Entity.GetComponent<AttackComponent>();

                attack.Target = null;
            }
        }
    }
}
