using Scellecs.Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

namespace Assets._Project.Scripts.ECS.Shooting
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct ShootComponent : IComponent
    {
        public FireConfig Config;
        public Transform SpawnPosition;
        public float EllapsedTime;
        internal bool IsFireing;
    }
}
