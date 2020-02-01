using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : Item
{
    public bool casingBroken, mechanismBroken, hasDecor;
    public bool[] componentBroken, hasMechComponent;

    public int[] componentOrder = new int[] { 0, 1, 2, 3, 4, 5, 6 };
    public int[] componentOrderNoDecor = new int[] { 0, 1, 2, 3, 4, 5 };

    public int componentsBroken;
    public int casingID;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = GetComponent<SpriteRenderer>().sprite;
        activator = GetComponentInParent<Activator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            RandomiseComponents(3, 7);
            ListComponents();
        }
        if (!knownState) stateSprite.sprite = unknownImage;
        else if (unfixable) stateSprite.sprite = unfixableImage;
        else if (broken) stateSprite.sprite = brokenImage;
        else stateSprite.sprite = repairedImage;
    }

    //No more than 7 broken basic components
    public void RandomiseComponents(int minBroken, int maxBroken)
    {
        componentBroken = new bool[7];
        hasMechComponent = new bool[3];

        componentsBroken = Random.Range(minBroken, maxBroken);
        Shuffle();

        for(int i = 0; i < componentsBroken; i++)
        {
            if(hasDecor)
            {
                componentBroken[componentOrder[i]] = true;
            }
            else if(i != 6)
            {
                componentBroken[componentOrderNoDecor[i]] = true;
            }
        }

        if (componentBroken[0] || componentBroken[1] || componentBroken[2])
        {
            casingBroken = true;
        }
        else casingBroken = false;

        if (componentBroken[3] || componentBroken[4] || componentBroken[5])
        {
            mechanismBroken = true;
        }
        else mechanismBroken = false;
        
        for(int i = 3; i < 6; i++)
        {
            int rand = Random.Range(0, 2);
            if (!componentBroken[i] && rand == 0)
            {
                Debug.Log(rand);
                hasMechComponent[i - 3] = false;
            }
            else hasMechComponent[i - 3] = true;
        }
    }

    public void Shuffle()
    {
        if(hasDecor)
        {
            int n = 7;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, 6);
                int value = componentOrder[k];
                componentOrder[k] = componentOrder[n];
                componentOrder[n] = value;
            }
        }
        else
        {
            int n = 6;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, 5);
                int value = componentOrderNoDecor[k];
                componentOrderNoDecor[k] = componentOrderNoDecor[n];
                componentOrderNoDecor[n] = value;
            }
        }
        
    }

    //Testing only
    private void ListComponents()
    {
        for (int i = 0; i < 7; i++)
        {
            Debug.Log("Component " + (i + 1) + " broken " + componentBroken[i]);
        }
        Debug.Log("Casing broken " + casingBroken);
        Debug.Log("Mech broken " + mechanismBroken);
        for(int i = 0; i < 3; i++)
        {
            Debug.Log("Mech component " + (i + 1) + " exists " + hasMechComponent[i]);
        }
    }
}
