using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Health;
using Assets._Project.Scripts.ECS.Player;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;


namespace Assets._Project.Scripts.ECS.Enemy
{
    public class EnemyProvider : MonoProvider<EnemyMarker>
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out PlayerProvider entityProvider))
            {
                if (entityProvider.Entity.IsDisposed())
                    return;

                if (entityProvider.Entity.Has<HealthComponent>() == false)
                    return;

                ref HealthComponent health = ref entityProvider.Entity.GetComponent<HealthComponent>();

                ref Attack attack = ref Entity.GetComponent<Attack>();

                if (attack.IsReadyAttack == false)
                    return;

                entityProvider.Entity.SetComponent(new Damage { Value = attack.Damage });
                attack.IsReadyAttack = false;
            }
        }
    }
}
