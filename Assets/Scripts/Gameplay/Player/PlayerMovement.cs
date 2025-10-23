using UnityEngine;

public class PlayerMovement : PlayerComponent
{

    public PlayerMovement(PlayerController playerController) : base(playerController)
    {

    }

    public override void OnEnable()
    {

    }

    public override void OnDisable()
    {

    }

    public override void Update()
    {
        // Read 2D movement input (Vector2)
        Vector2 input = _playerController.GetPlayerComponent<PlayerInput>().MoveInput;

        // Compute movement delta
        Vector3 delta = new Vector3(input.x, input.y, 0f) * _playerController.Stats.MoveSpeed * Time.deltaTime;

        // Apply translation on X/Y (2D)
        _playerController.transform.position += delta;
    }
}