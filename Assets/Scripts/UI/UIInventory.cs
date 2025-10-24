using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] UIInventorySlot _slotPrefab;
    [SerializeField] Transform _slotContainer;
    private List<UIInventorySlot> _slots;

    void Awake()
    {
        _slots = new();
    }

    void OnEnable()
    {
        for (int i = 0; i < InventorySystem.Instance.Model.Solts.Count; i++)
        {
            UIInventorySlot slot = Instantiate(_slotPrefab, _slotContainer);
            _slots.Add(slot);
        }
        
        InventorySystem.Instance.Model.OnChanged += RefreshInventoryUI;
    }

    void OnDisable()
    {
        InventorySystem.Instance.Model.OnChanged -= RefreshInventoryUI;
    }

    private void RefreshInventoryUI()
    {
        var slots = InventorySystem.Instance.Model.Solts;
        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].UpdateSolt(slots[i]);
        }
    }
}
