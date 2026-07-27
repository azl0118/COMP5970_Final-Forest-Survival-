using TMPro;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;

    public Inventory inventory;

    public ItemData woodItem;
    public ItemData oreItem;
    public ItemData crystalItem;

    private bool swordCrafted;

    void Start()
    {
        UpdateObjective();
    }

    void Update()
    {
        UpdateObjective();
    }

    public void SetSwordCrafted()
    {
        swordCrafted = true;
        UpdateObjective();
    }

    void UpdateObjective()
    {
        if (objectiveText == null)
        {
            return;
        }

        if (swordCrafted)
        {
            objectiveText.text =
                "Objective\n\n" +
                "Defeat the Bear\n" +
                "Left Click - Attack\n" +
                "Press 2 - Equip Sword\n";
            return;
        }

        int woodAmount = inventory.GetItemAmount(woodItem);
        int oreAmount = inventory.GetItemAmount(oreItem);
        int crystalAmount = inventory.GetItemAmount(crystalItem);

        objectiveText.text =
            "Objective\n\n" +
            "Craft a Sword\n" +
            "Wood: " + woodAmount + " / 5\n" +
            "Ore: " + oreAmount + " / 3\n" +
            "Crystals: " + crystalAmount + " / 2\n";
    }
}