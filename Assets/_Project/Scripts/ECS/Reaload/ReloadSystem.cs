using Assets._Project.Scripts.ECS.Damageable;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Assets._Project.Scripts.ECS.Attack;
using AttackComponent = Assets._Project.Scripts.ECS.Attack.Attack;
namespace Assets._Project.Scripts.ECS.Reaload
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ReloadSystem))]
    public sealed class ReloadSystem:UpdateSystem
    {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<AttackComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref AttackComponent attack = ref entity.GetComponent<AttackComponent>();

                if (attack.IsReadyToAttack)
                    continue;

                attack.EllapsedTime += deltaTime;

                if (attack.EllapsedTime >= attack.RealoadTime)
                {
                    attack.IsReadyToAttack = true;
                    attack.EllapsedTime = 0;
                }
            }
        }
    }
}
