public class PlayerStats
{
    public float MoveSpeed { get; private set; }

    public PlayerStats(PlayerSettings settings)
    {
        MoveSpeed = settings.MoveSpeed;
    }
}