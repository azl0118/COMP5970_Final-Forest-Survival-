using UnityEngine;
using TMPro;

public class ResourceCounter : MonoBehaviour
{

    public TextMeshProUGUI appleText;
    public TextMeshProUGUI oreText;
    public TextMeshProUGUI crystalText;
    public TextMeshProUGUI swordText;


    private int apples;
    private int ores;
    private int crystals;
    private int sword;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }


    private void UpdateUI()
    {
        appleText.text = "Apples: " + apples;
        oreText.text = "Ores: " + ores;
        crystalText.text = "Crystals: " + crystals;
        swordText.text = "Sword: " + sword;
    }

    public void AddResource(string resourceName, int amount)
    {
        if (resourceName == "Apple")
        {
            apples += amount;
        }
        else if (resourceName =="Ore")
        {
             ores += amount;
        }
        else if (resourceName == "Crystal")
        {
            crystals += amount;
        }

        else if (resourceName == "Sword")
        {
            sword += amount;
        }
        UpdateUI();
    }

}
