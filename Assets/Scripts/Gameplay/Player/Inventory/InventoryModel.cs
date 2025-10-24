using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    public List<InventorySoltModel> Solts { get; }
    public event Action OnChanged;

    public InventoryModel(int size)
    {
        Solts = new();
        for (int i = 0; i < size; i++)
        {
            InventorySoltModel slot = new();
            slot.Id = null;
            slot.Amount = 0;
            Solts.Add(slot);
        }
    }
    
    public void NotifyChanged()
    {
        OnChanged?.Invoke();
    }
}