using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite image;
    public string itemName;
    public int itemID;
    public bool broken;
    public bool beyondRepair;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    player.carriedItem = GameManager.instance.items[itemID];
                    player.carriesItem = true;
                    player.freeTooPickup = false;
                    player.itemSprite.sprite = image;
                    Destroy(gameObject);
                    gameObject.SetActive(false);
                }
                else
                {
                    player.carriedItem = GameManager.instance.items[itemID];
                    player.carriesItem = true;
                    player.freeTooPickup = false;
                    player.itemSprite.sprite = image;
                    Destroy(gameObject);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
