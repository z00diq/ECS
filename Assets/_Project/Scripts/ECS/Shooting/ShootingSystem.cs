using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Scellecs.Morpeh;
using System;
using Assets._Project.Scripts.ECS.Damageable;
using Unity.VisualScripting;
using Scellecs.Morpeh.Providers;

namespace Assets._Project.Scripts.ECS.Shooting
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ShootingSystem))]
    public sealed class ShootingSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<ShootComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref ShootComponent shoot = ref entity.GetComponent<ShootComponent>();

                shoot.EllapsedTime += deltaTime;

                if (shoot.EllapsedTime < shoot.Config.FireRate)
                    continue;

                if (shoot.IsFireing == false)
                    continue;

                SpawnBullet(shoot);

                shoot.EllapsedTime = 0;
            }
        }

        private void SpawnBullet(ShootComponent shoot)
        {
            FireBallProvider bulletView =Instantiate(shoot.Config.Prefab, shoot.SpawnPosition.position, Quaternion.identity);
            bulletView.AddComponent<RemoveEntityOnDestroy>();
            Entity bullet = bulletView.Entity;
            bullet.SetComponent(new TransformComponent { Transform = bulletView.transform });
            bullet.SetComponent(new Damage { IsReadyAttack = true, Value = shoot.Config.Damage});
            bullet.SetComponent(new MoveComponent 
            { 
                Position = bulletView.transform.position, 
                Direction = shoot.SpawnPosition.forward, 
                Speed = shoot.Config.Speed 
            });
        }
    }
}
