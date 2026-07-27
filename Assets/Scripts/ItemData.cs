using System.Net.Http.Headers;
using UnityEngine;

public enum ItemType
{
    Resource,
    Weapon
}
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item" )]
public class ItemData : ScriptableObject 

{
    public string itemName;
    public Sprite icon;
    public int maxStackSize = 5;

    [Header("Item Type")]
    public ItemType type;

    [Header("Weapon Settings")]
    public int damage;
    public float attackRange = 2.5f;
}
