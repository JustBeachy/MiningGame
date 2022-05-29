using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Elements : MonoBehaviour
{
    public bool isDirtLayer;
    public List<Sprite> elementList;
    public List<Sprite> crackList;
    public GameObject crackObject;
    int mineDifficulty;
    public GameObject particle;
    public GameObject inventoryObject;
    public GameObject furnace;
    public GameObject press;
    float crackStatus = 0;
    bool tutorialElements = true;
    public Sprite diamond;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateParticle()
    {
        if (!StaticVars.HideParticles)
        {
            Sprite img = gameObject.GetComponent<Image>().sprite;
            var part1 = Instantiate(particle, transform);
            part1.GetComponent<Image>().sprite = img;
            var part2 = Instantiate(particle, transform);
            part2.transform.position = new Vector2(part2.transform.position.x - 200, part2.transform.position.y - 200);
            part2.GetComponent<Image>().sprite = img;
            var part3 = Instantiate(particle, transform);
            part3.GetComponent<Image>().sprite = img;
            part3.transform.position = new Vector2(part3.transform.position.x - 200, part3.transform.position.y + 200);
            var part4 = Instantiate(particle, transform);
            part4.GetComponent<Image>().sprite = img;
            part4.transform.position = new Vector2(part4.transform.position.x + 200, part4.transform.position.y + 200);
            var part5 = Instantiate(particle, transform);
            part5.GetComponent<Image>().sprite = img;
            part5.transform.position = new Vector2(part5.transform.position.x + 200, part5.transform.position.y - 200);
        }

    }

    void AddToInventory()
    {
        Sprite minedSprite = gameObject.GetComponent<Image>().sprite;

        if (StaticVars.FurnaceOn) // if furnace on
        {
            bool wasPressed=false;
            if (StaticVars.PressOn)//if press on
            {
                int iter = 0;
                foreach (Sprite s in press.GetComponent<FurnacePress>().MinedElement)
                {
                    if (minedSprite == s)
                    {
                        minedSprite = press.GetComponent<FurnacePress>().ToIngot[iter];
                        wasPressed = true;
                    }
                    iter++;
                }
            }
            if(!wasPressed)
            {
                int iterator = 0;
                foreach (Sprite s in furnace.GetComponent<FurnacePress>().MinedElement)
                {
                    if (minedSprite == s)
                        minedSprite = furnace.GetComponent<FurnacePress>().ToIngot[iterator];
                    iterator++;
                }
            }

        }
        foreach (GameObject g in inventoryObject.GetComponent<Inventory>().InventoryArray)
        {
            
            if (g.GetComponent<Image>().sprite == minedSprite)
                g.GetComponent<InventoryItem>().AddOne();
        }

    }

    void NewElement()
    {
        if (gameObject.GetComponent<Image>().sprite == diamond)
            print("You Win!");

        CreateParticle();
        AddToInventory();

        crackStatus = 0;
        crackObject.GetComponent<Image>().sprite = crackList[0];

        System.Random rand = new System.Random();
        int randNum = rand.Next(1, 1001);

        if (tutorialElements)
        {
            randNum = 1;
            tutorialElements = false;
        }

        if (randNum > 0)
        {
            GetComponent<Image>().sprite = elementList[0];
            mineDifficulty = 0;
        }
        if (randNum > 300)
        {
            GetComponent<Image>().sprite = elementList[1];
            mineDifficulty = 0;
        }
        if (randNum > 550)
        {
            GetComponent<Image>().sprite = elementList[2];
            mineDifficulty = 0;
        }
        if (randNum > 700 )
        {
            GetComponent<Image>().sprite = elementList[3];
            mineDifficulty = 0;
        }
        if (randNum > 800)
        {
            GetComponent<Image>().sprite = elementList[4];
            mineDifficulty = 0;
        }
        if (randNum > 900)
        {
            GetComponent<Image>().sprite = elementList[5];
            mineDifficulty = 0;
        }
        if (randNum > 950 )
        {
            GetComponent<Image>().sprite = elementList[6];
            mineDifficulty = 0;
        }
        if (randNum == 1000 )
        {
            GetComponent<Image>().sprite = elementList[7];
            mineDifficulty = 7;
        }


    }

    public void Clicked()
    {
        int multiplier;
        if (isDirtLayer)
            multiplier = StaticVars.topsoilMineMultiplier;
        else
            multiplier = StaticVars.mineralMineMultiplier;


        if (crackStatus + (1.9f / ((float)mineDifficulty + 1f)) * (float)multiplier < (crackList.Count - 1))
        {
            crackStatus +=  (1.9f/((float)mineDifficulty+1f))*(float)multiplier;
            crackObject.GetComponent<Image>().sprite = crackList[(int)crackStatus];
        
        }
        else
            NewElement();

        
    }
}
