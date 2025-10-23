using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _inventoryPanel;
    private InputSystem_Actions _inputActions;
    void Awake()
    {
        _inputActions = new();
    }

    void OnEnable()
    {
        _inputActions.UI.Enable();
        _inputActions.UI.Inventory.performed += ToggleInventoryPanel;
    }

    void OnDisable()
    {
        _inputActions.UI.Inventory.performed -= ToggleInventoryPanel;
        _inputActions.UI.Disable();       
    }

    // Toggle the visibility of the inventory panel
    public void ToggleInventoryPanel(InputAction.CallbackContext context)
    {
        _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
    }
}