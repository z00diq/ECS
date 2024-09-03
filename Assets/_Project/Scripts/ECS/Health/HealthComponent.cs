using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Assets._Project.Scripts.ECS.Health
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    internal struct HealthComponent: IComponent
    {
        public int Value;
    }
}
