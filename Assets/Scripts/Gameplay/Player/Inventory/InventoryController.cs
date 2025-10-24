using UnityEngine;

public class InventoryController
{
    private InventoryModel _model;

    public InventoryController(InventoryModel model)
    {
        _model = model;
    }

    public int AddItem(string id, int amount)
    {
        int amountRemaining = amount;

        // search slot that store same item
        for (int i = 0; i < _model.Solts.Count; i++)
        {
            if (_model.Solts[i].Id == id)
            {
                amountRemaining = AddItem(id, amountRemaining, i);
                if (amountRemaining <= 0)
                {
                    _model.NotifyChanged();
                    return amountRemaining;
                }
            }
        }

        // try to put items into empty slot
        for (int i = 0; i < _model.Solts.Count; i++)
        {
            if (_model.Solts[i].Id == null)
            {
                amountRemaining = AddItem(id, amountRemaining, i);
                if (amountRemaining <= 0)
                {
                    _model.NotifyChanged();
                    return amountRemaining;
                }
            }
        }
        _model.NotifyChanged();
        return amountRemaining;
    }

    public int AddItem(string id, int amount, int index)
    {
        InventorySoltModel slot = _model.Solts[index];
        if (slot.Id != null && slot.Id != id)
        {
            Debug.LogError("Can't put different type of items into one slot!");
        }
        slot.Id = id;
        slot.Amount += amount;
        ItemData item = GameDatabase.Instance.Items.GetItemById(id);

        int remaining = slot.Amount - item.MaxStack;
        if (remaining > 0)
        {
            slot.Amount = item.MaxStack;
        }
        else
        {
            remaining = 0;
        }
        _model.Solts[index] = slot;
        return remaining;
    }

    public void RemoveItem(int index, int amount)
    {
        InventorySoltModel slot = _model.Solts[index];

        if (slot.Id == null)
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
            slot.Id = null;
        }
        _model.NotifyChanged();
    }
}