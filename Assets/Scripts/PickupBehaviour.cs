using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField]
    private MoveBehaviour playerMoveBehaviour;

    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private Animator playerAnimator;

    private Item currentItem;

    public void DoPickup(Item item)
    {
        if(inventory.isFull())
        {
            Debug.Log("Inventory full, can't pickup  : " + item.name);
            return;
        }

        currentItem = item;

        //play pickup animation
        playerAnimator.SetTrigger("Pickup");

        //block moving for character
        playerMoveBehaviour.canMove = false;
    }

    public void AddItemToInventory()
    {
        //Add the item in the inventory
        inventory.AddItem(currentItem.itemData);

        Destroy(currentItem.gameObject);

        currentItem = null;
    }

    public void ReEnablePlayerMovement()
    {
        playerMoveBehaviour.canMove = true;
    }
}
