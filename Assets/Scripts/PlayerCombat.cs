using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public HandSlot leftHand;
    public HandSlot rightHand;

    ItemWorld nearItem;

    private void Update()
    {
        if (!rightHand.IsBlocking())
        {
            leftHand.ProcessInput(0);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            leftHand.ActionUp();
        }
        
        if (!leftHand.IsBlocking())
        {
            rightHand.ProcessInput(1);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            rightHand.ActionUp();
        }

        if (Input.GetKeyDown(KeyCode.F) && nearItem != null)
        {
            TryPick(nearItem);
        }
    }

    

    void TryPick(ItemWorld item)
    {
        WeaponsData newWeapon = item.weaponData;
       
        if (newWeapon.twoHands)
        {
            if (!leftHand.IsEmpty()) leftHand.Drop();
            if (!rightHand.IsEmpty()) rightHand.Drop();
            leftHand.Pickup(newWeapon);
            leftHand.SetHandVisible(false);
            rightHand.SetHandVisible(false);
        }
        else
        {

            if (!leftHand.IsEmpty() && leftHand.GetCurrentData().twoHands)
            {
                leftHand.Drop();
                leftHand.SetHandVisible(true);
                rightHand.SetHandVisible(true);
            }
            if (leftHand.IsEmpty())
            {
                leftHand.Pickup(newWeapon);
                leftHand.SetHandVisible(false);
            }
            else if (rightHand.IsEmpty())
            {
                rightHand.Pickup(newWeapon);
                rightHand.SetHandVisible(false);
            }
            else
            {
                rightHand.Drop();
                rightHand.Pickup(newWeapon);
                rightHand.SetHandVisible(false);
            }
        }
        Destroy(item.gameObject);
        nearItem= null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            nearItem = collision.GetComponent<ItemWorld>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            
            if (nearItem != null && collision.gameObject == nearItem.gameObject)
            {
                nearItem = null;
            }
        }
    }
}
