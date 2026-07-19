using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI stackCount;

    public void SetSlot(ItemData item, int amount)
    {
        itemIcon.sprite = item.icon;
        itemIcon.gameObject.SetActive(true);

        stackCount.text = amount.ToString();
        stackCount.gameObject.SetActive(true);

    }

    public void ClearSlot()
    {
        itemIcon.sprite = null;
        itemIcon.gameObject.SetActive(false);

        stackCount.text = "";
        stackCount.gameObject.SetActive(false);
    }
}
