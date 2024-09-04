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
    public sealed class OnTriggerDamageHandler : EntityProvider
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out EntityProvider attackProvider))
            {
                Debug.Log("EntityIdCollising" + attackProvider.Entity.ID);

                ref Attack attack = ref attackProvider.Entity.GetComponent<Attack>(out bool exist);

                if (exist == false)
                    return;

                if (attack.IsReadyAttack == false)
                    return;

                Entity.SetComponent(new Damage { Value = attack.Damage });

                attack.IsReadyAttack = false;                
            }
        }
    }
}
