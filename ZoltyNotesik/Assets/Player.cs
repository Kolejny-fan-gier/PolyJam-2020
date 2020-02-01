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
    public bool freeToPickup = true;

    public SpriteRenderer itemSprite;
    public Activator droppedItemActivator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //PODNOSZENIE I OPUSZCZANIE ITEMÓW
        if (carriesItem && Input.GetButtonDown("Pickup" + playerNumber) && freeToPickup)
        {
            DropItem();
        }
        if(Input.GetButtonUp("Pickup" + playerNumber))
        {
            freeToPickup = true;
        }
    }
    private void FixedUpdate()
    {
        //RUCH POSTACI
        float posX = Input.GetAxisRaw("Horizontal" + playerNumber);
        float posY = Input.GetAxisRaw("Vertical" + playerNumber);

        if (posX != 0 || posY != 0)
        {
            Vector2 movement = new Vector2(posX, posY).normalized * speed;
            body.velocity = movement;
        }
        else
        {
            body.velocity = Vector2.zero;
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
        freeToPickup = false;
    }
}
