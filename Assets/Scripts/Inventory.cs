using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventorySlotUI[] slotUIs;
    public InventorySlotData[] slots;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slots = new InventorySlotData[slotUIs.Length];
        UpdateUI();

    }

    public void AddItem(ItemData item, int amount)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                continue;
            }

            if (slots[i].item == item && slots[i].amount < item.maxStackSize)
            {
                int spaceLeft = item.maxStackSize - slots[i].amount;
                int amountToAdd = Mathf.Min(spaceLeft, amount);

                slots[i].amount += amountToAdd;
                amount -= amountToAdd;

                if (amount <= 0)
                {
                    UpdateUI();
                    return;
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                continue;
            }

            int amountToAdd = Mathf.Min(item.maxStackSize, amount);
            slots[i] = new InventorySlotData(item, amountToAdd);
            amount -= amountToAdd;


            if (amount <= 0)
            {
                UpdateUI(); 
                return;
            }
        }

        UpdateUI();

    }

    public bool HasItem(ItemData item, int amount)
    {
        int total = 0;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null && slots[i].item == item)
            {
                total += slots[i].amount;
            }
        }

        return total >= amount;
    }

    public bool RemoveItem(ItemData item, int amount)
    {
        if (!HasItem(item, amount))
            return false;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
                continue;

            if (slots[i].item != item)
                continue;

            if (slots[i].amount > amount)
            {
                slots[i].amount -= amount;
                UpdateUI();
                return true;
            }

            amount -= slots[i].amount;
            slots[i] = null;

            if (amount <= 0)
            {
                UpdateUI();
                return true;
            }
        }

        UpdateUI();
        return true;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            if (slots[i] == null) 
            {
                slotUIs[i].ClearSlot();
            }else
            {
                slotUIs[i].SetSlot(slots[i].item, slots[i].amount);
            }
        }
    }
}
