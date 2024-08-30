using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RenderSystem))]
public sealed class RenderSystem : UpdateSystem 
{
    private Filter _filter;

    public override void OnAwake() 
    {
        _filter = World.Filter.With<TransformComponent>().
            With<MoveComponent>().Build();
    }

    public override void OnUpdate(float deltaTime) 
    {
        foreach (Entity entity in _filter)
        {
            ref TransformComponent transform = ref entity.GetComponent<TransformComponent>();
            ref MoveComponent move = ref entity.GetComponent<MoveComponent>();

            transform.Transform.position = move.Position;

        }
    }
}