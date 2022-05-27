using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Craftable : MonoBehaviour
{
    public Sprite[] formulaSprites;
    public int[] formulaAmount;
    public string description;
    public GameObject inventory;
    public GameObject vertInfoBox;
    public bool crafted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        var box =Instantiate(vertInfoBox, transform.parent.parent);
        box.GetComponent<VerticalInfoBox>().SetInfo(gameObject.name, description, gameObject.GetComponent<Image>().sprite, 0, formulaSprites, formulaAmount);
           
    }

    public void Craft()
    {
        bool canCraft = false;
        int iterator = 0;
        foreach (Sprite s in formulaSprites)
        {
            foreach (GameObject g in inventory.GetComponent<Inventory>().InventoryArray)
            {
                if(g.GetComponent<Image>().sprite==s)
                {
                    if (g.GetComponent<InventoryItem>().quanitity >= formulaAmount[iterator])
                    {
                        canCraft = true;
                    }
                    else
                        canCraft = false;
                }
                iterator++;
            }
        }
        if (canCraft)
            crafted = true;
    }
}
