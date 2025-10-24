using UnityEngine;
using UnityEngine.UI;
public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _amount;

    public void UpdateSolt(InventorySoltModel soltModel)
    {
        if (soltModel.Id == null)
        {
            _icon.gameObject.SetActive(false);
            _amount.gameObject.SetActive(false);
            return;
        }

        ItemData item = GameDatabase.Instance.Items.GetItemById(soltModel.Id);
        Debug.Log($"[UI Inventory slot] Adding {soltModel.Id} x {soltModel.Amount}");
        _icon.sprite = item.Icon;
        _icon.gameObject.SetActive(true);

        _amount.text = soltModel.Amount.ToString();

        if (item.MaxStack == 1)
        {
            _amount.gameObject.SetActive(false);
        }
        else
        {
            _amount.gameObject.SetActive(true);
        }
    }
}
