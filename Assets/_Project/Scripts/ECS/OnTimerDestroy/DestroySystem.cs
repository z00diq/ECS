using Assets._Project.Scripts.ECS.Followable;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Assets._Project.Scripts.ECS.OnTimerDestroy
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(FollowSystem))]
    public class DestroySystem : UpdateSystem
    {
        private Filter _filter;
        public override void OnAwake()
        {
            _filter = World.Filter.With<Destroyable>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
               ref Destroyable destroyable = ref entity.GetComponent<Destroyable>();

                if (destroyable.EllapsedTime >= destroyable.LifeTime)
                    entity.Dispose();

                destroyable.EllapsedTime += deltaTime;
            }
        }
    }
}
