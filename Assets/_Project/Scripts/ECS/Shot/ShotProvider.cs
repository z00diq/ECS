using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Enemy;
using Assets._Project.Scripts.ECS.Health;
using Assets._Project.Scripts.ECS.Shot;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

public class ShotProvider : MonoProvider<ShotComponent>
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyProvider entityProvider))
        {
            ref HealthComponent health = ref entityProvider.Entity.GetComponent<HealthComponent>(out bool exist);

            ref Attack attack = ref Entity.GetComponent<Attack>();

            if (exist == false)
                return;

            entityProvider.Entity.SetComponent(new Damage { Value = attack.Damage });
            Entity.Dispose();
        }
    }
}