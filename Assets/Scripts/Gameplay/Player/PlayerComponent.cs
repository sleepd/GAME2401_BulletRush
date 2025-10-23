public abstract class PlayerComponent : IPlayerComponent
{
    protected PlayerController _playerController;
    public PlayerComponent(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public abstract void Update();

    public abstract void OnEnable();

    public abstract void OnDisable();
}