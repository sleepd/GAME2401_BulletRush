using UnityEngine;

public class InventoryController
{
    private InventoryModel _model;

    public InventoryController(InventoryModel model)
    {
        _model = model;
    }

    public int AddItem(ItemData item, int amount)
    {
        int amountRemaining = amount;

        // search slot that store same item
        for (int i = 0; i < _model.Solts.Count; i++)
        {
            if (_model.Solts[i].Item.Id == item.Id)
            {
                amountRemaining = AddItem(item, amountRemaining, i);
                if (amountRemaining <= 0) return amountRemaining;
            }
        }

        // try to put items into empty slot
        for (int i = 0; i < _model.Solts.Count; i++)
        {
            if (_model.Solts[i].Item == null)
            {
                amountRemaining = AddItem(item, amountRemaining, i);
                if (amountRemaining <= 0) return amountRemaining;
            }
        }

        return amountRemaining;
    }

    public int AddItem(ItemData item, int amount, int index)
    {
        InventorySoltModel slot = _model.Solts[index];
        if (slot.Item != null && slot.Item.Id != item.Id)
        {
            Debug.LogError("Can't put different type of items into one slot!");
        }
        slot.Item = item;
        slot.Amount += amount;
        int remaining = slot.Item.MaxStack - slot.Amount;
        if (remaining > 0)
        {
            slot.Amount = slot.Item.MaxStack;
        }
        else
        {
            remaining = 0;
        }

        return remaining;
    }

    public void RemoveItem(int index, int amount)
    {
        InventorySoltModel slot = _model.Solts[index];

        if (slot.Item == null)
        {
            Debug.LogWarning("Trying to remove item, but the slot is empty.");
            return;
        }

        slot.Amount -= amount;
        if (slot.Amount < 0)
        {
            Debug.LogError("Trying to remove more items than the slot contains.");
            return;
        }

        if (slot.Amount == 0)
        {
            slot.Item = null;
        }
    }
}