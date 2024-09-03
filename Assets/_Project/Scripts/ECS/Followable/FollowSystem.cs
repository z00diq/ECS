using Assets._Project.Scripts.ECS.Damageable;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using System;
using Unity.IL2CPP.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets._Project.Scripts.ECS.Followable
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(FollowSystem))]
    public sealed class FollowSystem : UpdateSystem
    {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<FollowComponent>().
                With<MoveComponent>().
                Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref MoveComponent move = ref entity.GetComponent<MoveComponent>();
                ref FollowComponent follow = ref entity.GetComponent<FollowComponent>();

                if(follow.Target == null)
                {
                    move.Direction = Vector3.zero;
                    entity.RemoveComponent<FollowComponent>();
                    continue;
                }

                Vector3 distance = move.Position - follow.Target.position;

                if (distance.magnitude <= follow.TargetOffset)
                {
                    move.Direction = Vector3.zero;
                }
                else
                {
                    Vector3 direction = follow.Target.position - move.Position;
                    move.Direction = direction.normalized;
                }
            }
        }
    }
}
