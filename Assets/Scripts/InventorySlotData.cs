using Unity.VisualScripting;
using UnityEngine;

public class InventorySlotData
// Start is called once before the first execution of Update after the MonoBehaviour is created
{
    public ItemData item;
    public int amount;



    public InventorySlotData(ItemData item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}