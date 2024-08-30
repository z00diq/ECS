using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using Assets._Project.Scripts.Extentions;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(InputProviderSystem))]
public sealed class InputProviderSystem : UpdateSystem
{
    private Camera _camera;
    private Filter _filter;
    private Vector3 _reflectedInput;
    private Vector3 _rotatatePosition;

    public override void OnAwake() 
    {
        _filter = World.Filter.With<InputComponent>().
            With<MoveComponent>().
            With<RotationComponent>().
            With<TransformComponent>().Build();

        _camera = Camera.main;
    }

    public override void OnUpdate(float deltaTime) 
    {
        foreach (Entity entity in _filter)
        {
            ref MoveComponent move = ref entity.GetComponent<MoveComponent>();
            ref InputComponent input = ref entity.GetComponent<InputComponent>();
            ref RotationComponent rotate = ref entity.GetComponent<RotationComponent>();
            ref TransformComponent transform = ref entity.GetComponent<TransformComponent>();

            Ray ray = _camera.ScreenPointToRay(input.MousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                rotate.ToRotate = hit.point;

            //move.Direction.z = transform.Transform.forward.z * input.Input.y;
            //move.Direction.x = transform.Transform.right.x * input.Input.x;
            Vector3 direction = transform.Transform.forward * input.Input.y + transform.Transform.right * input.Input.x;
            move.Direction = direction;
        }
    }
}