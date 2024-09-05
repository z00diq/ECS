using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Enemy;
using Assets._Project.Scripts.ECS.Health;
using Assets._Project.Scripts.ECS.Shot;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;
using AttackComponent = Assets._Project.Scripts.ECS.Attack.Attack;
public class ShotProvider : MonoProvider<ShotComponent>
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyProvider entityProvider))
        {
            if (entityProvider.Entity.Has<HealthComponent>() == false)
                return;

            ref AttackComponent attack = ref Entity.GetComponent<AttackComponent>();

            attack.Target = entityProvider.Entity;
        }
    }
}