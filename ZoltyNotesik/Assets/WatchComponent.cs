using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchComponent : Item
{
    public bool[] componentBroken;
    public bool[] componentExists;
    public int[] componentID;

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
}
