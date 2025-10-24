using UnityEngine;

public class InventorySystem : Singleton<InventorySystem>
{
    [SerializeField] private int initialSize = 20;
    private InventoryModel _model;
    private InventoryController _controller;

    public InventoryModel Model => _model;
    public InventoryController Controller => _controller;
    public override void Awake()
    {
        base.Awake();
        _model = new InventoryModel(initialSize);
        _controller = new InventoryController(_model);
    }
}