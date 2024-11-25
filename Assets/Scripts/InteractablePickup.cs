using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractablePickup : MonoBehaviour
{
    [SerializeField] private ItemSO itemToPickup;
    [SerializeField] private TextMeshProUGUI textToDisplay;

    [SerializeField] private KeyCode pickupKey;
    [SerializeField] private KeyCode dropKey;
    private bool insideTrigger = false;
    private bool canDisplay = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!canDisplay)
            return;
        
        textToDisplay.text = "Pickup";
        insideTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!canDisplay)
            return;
        
        textToDisplay.text = "";
        insideTrigger = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(pickupKey) && insideTrigger)
        {
            Player.Instance.Inventory.Add(itemToPickup);
            canDisplay = false;
        }
        
        if (Input.GetKeyDown(dropKey))
        {
            Player.Instance.Inventory.Remove(itemToPickup);
            canDisplay = true;
        }
    }
}
