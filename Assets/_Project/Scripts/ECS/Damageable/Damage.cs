using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Assets._Project.Scripts.ECS.Damageable
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct Damage : IComponent
    {
        public bool IsReadyAttack;
        public float RealoadTime;
        public float EllapsedTime;
        public int Value;
    }
}
