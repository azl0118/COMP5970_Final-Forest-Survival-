using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public Inventory inventory;

    [Header("Recipe")]
    public ItemData wood;
    public ItemData ore;
    public ItemData sword;

    public int woodRequired = 3;
    public int oreRequired = 2;

    public void CraftSword()
    {
        if (!inventory.HasItem(wood, woodRequired))
        {
            Debug.Log("Not enough wood.");
            return;
        }

        if (!inventory.HasItem(ore, oreRequired))
        {
            Debug.Log("Not enough stone.");
            return;
        }

        inventory.RemoveItem(wood, woodRequired);
        inventory.RemoveItem(ore, oreRequired);

        inventory.AddItem(sword, 1);

        Debug.Log("Sword crafted!");
    }
}