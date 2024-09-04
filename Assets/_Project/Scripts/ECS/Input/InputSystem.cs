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

    public override void OnAwake() 
    {
        _filter = World.Filter.With<InputComponent>().Build();
    }

    public override void OnUpdate(float deltaTime) 
    {
        Vector2 inputVector = new();
         
        foreach (Entity entity in _filter)
        {
            ref InputComponent input = ref entity.GetComponent<InputComponent>();

            inputVector.x = Input.GetAxisRaw(Horizontal);
            inputVector.y = Input.GetAxisRaw(Vertical);
            bool LMBPressed = Input.GetMouseButton(0);
            input.Input = inputVector;
            input.MousePosition = Input.mousePosition;
            input.IsLeftMouseButtonPressed = LMBPressed;
        }
    }
}