using UnityEngine;

public class PlayerInput : PlayerComponent
{
    public Vector2 MoveInput { get => _inputActions.Player.Move.ReadValue<Vector2>(); }
    private InputSystem_Actions _inputActions;
    public PlayerInput(PlayerController playerController) : base(playerController)
    {
        
        _inputActions = new();
    }

    public override void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    public override void OnDisable()
    {
        _inputActions.Player.Disable();
    }

    public override void Update()
    {

    }
    

}