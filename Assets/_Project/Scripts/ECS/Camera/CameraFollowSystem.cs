using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Followable;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;


namespace Assets._Project.Scripts.ECS.Camera
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CameraFollowSystem))]
    public class CameraFollowSystem : LateUpdateSystem
    {
        private Vector3 _offset;
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<FollowComponent>().
                With<CameraMarker>().
                With<TransformComponent>().
                Build();

            Entity camera = _filter.First();

            Transform self = camera.GetComponent<TransformComponent>().Transform;
            Transform target = camera.GetComponent<FollowComponent>().Target;

            _offset = target.position - self.position;

        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                Transform self = entity.GetComponent<TransformComponent>().Transform;
                Transform target = entity.GetComponent<FollowComponent>().Target;

                self.transform.position = target.position - _offset;
            }
        }
    }
}
