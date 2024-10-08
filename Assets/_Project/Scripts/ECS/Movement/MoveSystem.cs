using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MoveSystem))]
public sealed class MoveSystem : UpdateSystem 
{
    private Filter _filter;

    public override void OnAwake() 
    {
        _filter = World.Filter.With<MoveComponent>().Build();
    }

    public override void OnUpdate(float deltaTime) 
    {
        foreach (Entity entity in _filter)
        {
            ref MoveComponent move = ref entity.GetComponent<MoveComponent>();
            Vector3 newPosition = deltaTime * move.Speed * move.Direction;

            move.Position += newPosition;
        }
    }
}