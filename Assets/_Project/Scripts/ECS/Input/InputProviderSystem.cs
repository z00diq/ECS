using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using Assets._Project.Scripts.ECS.Shooting;
using Assets._Project.Scripts.ECS.Camera;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(InputProviderSystem))]
public sealed class InputProviderSystem : UpdateSystem
{
    private Filter _cameraFilter;
    private Filter _filter;

    public override void OnAwake() 
    {
        _filter = World.Filter.With<InputComponent>().
            With<MoveComponent>().
            With<RotationComponent>().
            With<TransformComponent>().
            With<ShootComponent>().
            Build();

        _cameraFilter = World.Filter.With<CameraComponent>().Build();
    }

    public override void OnUpdate(float deltaTime) 
    {
        Entity cameraEntity = _cameraFilter.FirstOrDefault();

        if (cameraEntity == null)
            return;

        foreach (Entity entity in _filter)
        {
            ref MoveComponent move = ref entity.GetComponent<MoveComponent>();
            ref InputComponent input = ref entity.GetComponent<InputComponent>();
            ref RotationComponent rotate = ref entity.GetComponent<RotationComponent>();
            ref TransformComponent transform = ref entity.GetComponent<TransformComponent>();
            ref ShootComponent shoot = ref entity.GetComponent<ShootComponent>();

            Camera camera = cameraEntity.GetComponent<CameraComponent>().Camera;


            Ray ray = camera.ScreenPointToRay(input.MousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                rotate.ToRotate = hit.point;

            shoot.IsFireing = input.IsLeftMouseButtonPressed;
            
            Vector3 direction = transform.Transform.forward * input.Input.y + transform.Transform.right * input.Input.x;
            move.Direction = direction.normalized;
        }
    }
}