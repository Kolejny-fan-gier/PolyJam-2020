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
    public SpriteRenderer itemStateSprite;
    public Activator droppedItemActivator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //OPUSZCZANIE ITEMÓW
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
        float moveX = Input.GetAxisRaw("Horizontal" + playerNumber);
        float moveY = Input.GetAxisRaw("Vertical" + playerNumber);

        if (moveX != 0 || moveY != 0)
        {
            Vector2 movement = new Vector2(moveX, moveY).normalized * speed;
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
        itemStateSprite.sprite = null;
        carriesItem = false;
        freeToPickup = false;
    }
}
