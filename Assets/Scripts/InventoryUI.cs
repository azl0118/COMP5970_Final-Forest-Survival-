using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{

    public GameObject inventoryScreen;

    private bool isOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (inventoryScreen != null)
        {
            inventoryScreen.SetActive(false);
        }
    }

    public void OnInventory(InputValue value)
    {
        if (!value.isPressed)
        {
            return;
        }

        ToggleInventory();


    }

    private void ToggleInventory()
    {
        isOpen = !isOpen;
        if (inventoryScreen != null)
        {
            inventoryScreen.SetActive(isOpen);
        }
    }
}
