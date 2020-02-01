using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber;
    public Vector2 speed;
    public Rigidbody2D body;

    public Item carriedItem;
    public bool carriesItem;
    public bool freeTooPickup;

    public SpriteRenderer itemSprite;
    public Activator droppedItemActivator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //RUCH POSTACI
        float posX = Input.GetAxisRaw("Horizontal" + playerNumber);
        float posY = Input.GetAxisRaw("Vertical" + playerNumber);

        if(posX != 0 || posY != 0)
        {
            Vector2 movement = new Vector2(posX, posY).normalized * speed;
            body.velocity = movement;
        }
        else
        {
            body.velocity = Vector2.zero;
        }

        //PODNOSZENIE I OPUSZCZANIE ITEMÓW
        if (carriesItem && Input.GetButtonDown("Pickup" + playerNumber) && freeTooPickup)
        {
            DropItem();
        }
        if(Input.GetButtonUp("Pickup" + playerNumber))
        {
            freeTooPickup = true;
        }
    }

    void DropItem()
    {
        //Instantiate(carriedItem, transform.position, carriedItem.transform.rotation);
        droppedItemActivator.transform.position = transform.position;
        droppedItemActivator.SetChildState(true);
        //carriedItem = null;
        droppedItemActivator = null;
        itemSprite.sprite = null;
        carriesItem = false;
        freeTooPickup = false;
    }
}
