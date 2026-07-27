using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f;
    public TextMeshProUGUI promptText;

    public Inventory inventory;

    private InteractableResource currentResource;
    private Animator animator;
    private bool isInteracting;
    private CraftingTable currentCraftingTable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (promptText != null)
        {
            promptText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindNearbyResource();
    }

    private void FindNearbyResource()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactionRange);

        currentResource = null;
        currentCraftingTable = null;

        float closestDistance = Mathf.Infinity;

        foreach (Collider hit in hits)
        {
            float distance = Vector3.Distance(transform.position, hit.transform.position);

            InteractableResource resource = hit.GetComponentInParent<InteractableResource>();

            if (resource != null && distance < closestDistance)
            {
                closestDistance = distance;
                currentResource = resource;
                currentCraftingTable = null;
                continue;
            }

            CraftingTable table = hit.GetComponentInParent<CraftingTable>();

            if (table != null && distance < closestDistance)
            {
                closestDistance = distance;
                currentCraftingTable = table;
                currentResource = null;
            }
        }

        if (promptText == null)
            return;

        if (!isInteracting)
        {
            if (currentResource != null)
            {
                promptText.text = currentResource.promptText;
                promptText.gameObject.SetActive(true);
            }
            else if (currentCraftingTable != null)
            {
                promptText.text = currentCraftingTable.promptText;
                promptText.gameObject.SetActive(true);
            }
            else
            {
                promptText.gameObject.SetActive(false);
            }
        }
    }

    public void OnInteract(InputValue value)
    {
        if (!value.isPressed)
            return;

        if (isInteracting)
            return;

        if (currentResource != null)
        {
            StartCoroutine(InteractRoutine());
        }
        else if (currentCraftingTable != null)
        {
            currentCraftingTable.Interact(inventory);
        }
    }

    private IEnumerator InteractRoutine()
    {
        isInteracting = true;

        if (promptText != null)
        {
            promptText.gameObject.SetActive(false);

        }

        if (animator != null && !string.IsNullOrEmpty(currentResource.animationTrigger))
        {
            animator.SetTrigger(currentResource.animationTrigger);
        }

        yield return new WaitForSeconds(0.8f);

        if (currentResource != null)
        {
            currentResource.Interact(inventory);
        }

        yield return new WaitForSeconds(0.3f);

        isInteracting = false;
    }
}
