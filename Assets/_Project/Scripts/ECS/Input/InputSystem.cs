using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(InputSystem))]
public sealed class InputSystem : UpdateSystem 
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private Filter _filter;
    private Vector2 _input;
    private Vector3 _mousePosition;

    public override void OnAwake() 
    {
        _filter = World.Filter.With<InputComponent>().Build();
    }

    public override void OnUpdate(float deltaTime) 
    {
        foreach (Entity entity in _filter)
        {
            ref InputComponent input = ref entity.GetComponent<InputComponent>();

            _input.x = Input.GetAxisRaw(Horizontal);
            _input.y = Input.GetAxisRaw(Vertical);
            bool LMBPressed = Input.GetMouseButton(0);
            input.Input = _input;
            input.MousePosition = Input.mousePosition;
            input.IsLeftMouseButtonPressed = LMBPressed;
        }
    }
}