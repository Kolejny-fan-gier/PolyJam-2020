using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite itemImage;
    public Sprite repairedImage;
    public Sprite brokenImage;
    public Sprite unfixableImage;
    public Sprite unknownImage;
    public SpriteRenderer stateSprite;
    //public string itemName;
    public int itemID;
    public bool broken;
    public bool unfixable;
    public bool knownState;

    public Activator activator;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = GetComponent<SpriteRenderer>().sprite;
        activator = GetComponentInParent<Activator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!knownState) stateSprite.sprite = unknownImage;
        else if (unfixable) stateSprite.sprite = unfixableImage;
        else if (broken) stateSprite.sprite = brokenImage;
        else stateSprite.sprite = repairedImage;
    }

    private void OnTriggerStay2D(Collider2D other)
    {   //ITEM WCHODZI W GRACZA
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            if (Input.GetButton("Pickup" + player.playerNumber) && !player.carriesItem && player.freeTooPickup)
            {
                if(player.playerNumber == 1)
                {
                    //player.carriedItem = GameManager.instance.items[itemID];
                    player.droppedItemActivator = activator;
                    player.carriesItem = true;
                    player.freeTooPickup = false;
                    player.itemSprite.sprite = itemImage;
                    //Destroy(gameObject);
                    gameObject.SetActive(false);
                }
                else
                {
                    //player.carriedItem = GameManager.instance.items[itemID];
                    player.droppedItemActivator = activator;
                    player.carriesItem = true;
                    player.freeTooPickup = false;
                    player.itemSprite.sprite = itemImage;
                    //Destroy(gameObject);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
