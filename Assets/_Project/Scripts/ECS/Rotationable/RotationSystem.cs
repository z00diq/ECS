using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RotationSystem))]
public sealed class RotationSystem : UpdateSystem 
{
    private Filter _filter;

    public override void OnAwake() 
    {
        _filter = World.Filter.With<TransformComponent>().
            With<RotationComponent>().Build();
    }

    public override void OnUpdate(float deltaTime) 
    {
        foreach (Entity entity in _filter)
        {
            ref TransformComponent transform =  ref entity.GetComponent<TransformComponent>();
            ref RotationComponent rotation =  ref entity.GetComponent<RotationComponent>();

            Vector3 newRotation = rotation.ToRotate - transform.Transform.position;
            newRotation.y = 0;
            transform.Transform.forward = newRotation;
        }
    }
}