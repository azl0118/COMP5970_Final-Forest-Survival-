using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public string promptText = "Press E to Craft Sword";

    public void Interact(Inventory inventory)
    {
        CraftingManager.Instance.CraftSword(inventory);
    }
}
