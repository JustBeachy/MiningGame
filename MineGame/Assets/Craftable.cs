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
    public bool canCraftMultiple;
    public int quantity;
    public Sprite onSprite, offSpritePress;
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
        box.GetComponent<VerticalInfoBox>().SetInfo(gameObject.name, description, gameObject.GetComponent<Image>().sprite, 0, formulaSprites, formulaAmount,gameObject);
           
    }

    public void Craft()
    {
        bool canCraft = false;
        int iterator = 0;
        foreach (Sprite s in formulaSprites)
        {
            
            foreach (GameObject g in inventory.GetComponent<Inventory>().InventoryArray)
            {
                if (g.GetComponent<Image>().sprite == s)
                {
                    if (g.GetComponent<InventoryItem>().quanitity >= formulaAmount[iterator])
                    {
                        canCraft = true;
                    }
                    else
                    {
                        canCraft = false;
                        goto End;
                    }
                }
                
                
            }
            iterator++;
        }
        End:
        if (canCraft) //craft it
        {
            crafted = true;
            RemoveFromInventory();
            if(onSprite!=null)
            GetComponent<Image>().sprite = onSprite;

            Image image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;

            //apply bonuses
            if (gameObject.name.Contains("Pickaxe"))
                StaticVars.mineralMineMultiplier *= 2;
            if (gameObject.name.Contains("Shovel"))
                StaticVars.topsoilMineMultiplier *= 2;
            if (gameObject.name.Contains("Crank"))
            {
                StaticVars.EnergyProduction += 2;
            }
            if (gameObject.name.Contains("Steam"))
            {
                StaticVars.EnergyProduction += 4;
                StaticVars.HideParticles = true;
            }
            if (gameObject.name.Contains("Combustion"))
            {
                StaticVars.EnergyProduction += 14;
                StaticVars.HideParticles = true;
            }
            if (gameObject.name.Contains("Solar"))
            {
                StaticVars.EnergyProduction += 40f;
                StaticVars.HideParticles = true;
            }
            if (gameObject.name.Contains("Furnace"))
                StaticVars.FurnaceOn =true;
            if (gameObject.name.Contains("Press"))
                StaticVars.PressOn=true;
            if (gameObject.name.Contains("Digger"))
                StaticVars.DiggerOn = true;
            if (gameObject.name.Contains("Miner"))
                StaticVars.MinerOn = true;

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StaticVars>().UpdateText();


        }
    }

    public void RemoveFromInventory()
    {
        int iterator = 0;
        foreach (Sprite s in formulaSprites)
        {

            foreach (GameObject g in inventory.GetComponent<Inventory>().InventoryArray)
            {
                if (g.GetComponent<Image>().sprite == s)
                {
                    if (g.GetComponent<InventoryItem>().quanitity >= formulaAmount[iterator])
                    {
                        g.GetComponent<InventoryItem>().quanitity -= formulaAmount[iterator];
                        g.GetComponent<InventoryItem>().RefreshQuantity();
                    }
                    
                        
                }


            }
            iterator++;
        }
    }
}
