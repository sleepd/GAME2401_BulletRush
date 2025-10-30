using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject _inventoryPanel;
    public InputSystem_Actions UIInputActions { get; private set; }

    public override void Awake()
    {
        base.Awake();
        UIInputActions = new();
    }

    void OnEnable()
    {
        UIInputActions.UI.Enable();
        UIInputActions.UI.Inventory.performed += ToggleInventoryPanel;
    }

    void OnDisable()
    {
        UIInputActions.UI.Inventory.performed -= ToggleInventoryPanel;
        UIInputActions.UI.Disable();       
    }

    // Toggle the visibility of the inventory panel
    public void ToggleInventoryPanel(InputAction.CallbackContext context)
    {
        _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
    }
}