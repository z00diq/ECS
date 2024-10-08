﻿using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Scellecs.Morpeh;
using Assets._Project.Scripts.ECS.OnTimerDestroy;
using AttackComponent =  Assets._Project.Scripts.ECS.Attack.Attack;

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

                SpawnShot(shoot);

                shoot.EllapsedTime = 0;
            }
        }

        private void SpawnShot(ShootComponent shoot)
        {
            TransformProvider shotView = Object.Instantiate(shoot.Config.Prefab, shoot.SpawnPosition.position, Quaternion.identity);
            Entity shot = shotView.Entity;

            shot.SetComponent(new AttackComponent { IsReadyToAttack = true, Damage = shoot.Config.Damage});
            shot.SetComponent(new Destroyable { LifeTime = shoot.Config.LifeTime });
            shot.SetComponent(new MoveComponent 
            { 
                Position = shotView.transform.position, 
                Direction = shoot.SpawnPosition.forward, 
                Speed = shoot.Config.Speed 
            });
        }
    }
}
