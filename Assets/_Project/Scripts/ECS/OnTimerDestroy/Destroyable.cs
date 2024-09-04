using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Assets._Project.Scripts.ECS.OnTimerDestroy
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct Destroyable : IComponent
    {
        public float LifeTime;
        public float EllapsedTime;
    }
}
