using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private float pickUpRange = 2.6f;
    public Inventory inventory;
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward, out hit, pickUpRange))
        {
            if (hit.transform.CompareTag("Item"))
            {
                Debug.Log("There's an Item");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventory.content.Add(hit.transform.gameObject.GetComponent<Item>().item);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
