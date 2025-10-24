using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    public List<InventorySoltModel> Solts { get; }
    
    public InventoryModel(int size)
    {
        for (int i=0; i<size; i++)
        {
            InventorySoltModel slot = new();
            slot.Item = null;
            slot.Amount = 0;
            Solts.Add(slot);
        }
    }
}