using UnityEngine;

public class GameDatabase : Singleton<GameDatabase>
{
    [Header("Databases")]
    [SerializeField] private ItemDatabase _itemDatabase;

    public ItemDatabase Items => _itemDatabase;

    public override void Awake()
    {
        base.Awake();

        if (_itemDatabase == null)
        {
            Debug.LogWarning("GameDatabase does not reference an ItemDatabase asset.");
        }
    }
}
