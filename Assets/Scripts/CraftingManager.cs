using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager Instance;
    public ObjectiveUI objectiveUI;

    public ItemData woodItem;
    public ItemData oreItem;
    public ItemData crystalItem;
    public ItemData swordItem;

    private void Awake()
    {
        Instance = this;
    }

    public void CraftSword(Inventory inventory)
    {
        if (!inventory.HasItem(woodItem, 5))
        {
            Debug.Log("Need 5 Wood.");
            return;
        }

        if (!inventory.HasItem(oreItem, 3))
        {
            Debug.Log("Need 3 Ore.");
            return;
        }

        if (!inventory.HasItem(crystalItem, 2))
        {
            Debug.Log("Need 2 Crystals.");
            return;
        }

        inventory.RemoveItem(woodItem, 5);
        inventory.RemoveItem(oreItem, 3);
        inventory.RemoveItem(crystalItem, 2);

        inventory.AddItem(swordItem, 1);

        if (objectiveUI != null)
        {
            objectiveUI.SetSwordCrafted();
        }

        Debug.Log("Sword Crafted!");
    }
}