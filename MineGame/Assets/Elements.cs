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
    int clickIndex;
    int currentElement;
    public GameObject particle;
    public GameObject inventoryObject;
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
        Sprite img = gameObject.GetComponent<Image>().sprite;
        var part1 = Instantiate(particle, transform);
        part1.GetComponent<Image>().sprite = img;
        var part2 = Instantiate(particle, transform);
        part2.transform.position = new Vector2(part2.transform.position.x-200, part2.transform.position.y-200);
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

    void AddToInventory()
    {
        foreach (GameObject g in inventoryObject.GetComponent<Inventory>().InventoryArray)
        {
            if (g.GetComponent<Image>().sprite == gameObject.GetComponent<Image>().sprite)
                g.GetComponent<InventoryItem>().AddOne();
        }

    }

    void NewElement()
    {
        CreateParticle();
        AddToInventory();


        clickIndex = 0;
        crackObject.GetComponent<Image>().sprite = crackList[clickIndex];

        System.Random rand = new System.Random();
        int randNum = rand.Next(1, 1001);

        if (randNum <= 300)
        {
            GetComponent<Image>().sprite = elementList[0];
            currentElement = 0;
        }
        if (randNum > 250 && randNum <= 450)
        {
            GetComponent<Image>().sprite = elementList[1];
            currentElement = 1;
        }
        if (randNum > 450 && randNum <= 600)
        {
            GetComponent<Image>().sprite = elementList[2];
            currentElement = 2;
        }
        if (randNum > 600 && randNum <= 750)
        {
            GetComponent<Image>().sprite = elementList[3];
            currentElement = 3;
        }
        if (randNum > 750 && randNum <= 850)
        {
            GetComponent<Image>().sprite = elementList[4];
            currentElement = 4;
        }
        if (randNum > 850 && randNum <= 920)
        {
            GetComponent<Image>().sprite = elementList[5];
            currentElement = 5;
        }
        if (randNum > 920 && randNum <= 990)
        {
            GetComponent<Image>().sprite = elementList[6];
            currentElement = 6;
        }
        if (randNum > 990 && randNum <= 1000)
        {
            GetComponent<Image>().sprite = elementList[7];
            currentElement = 7;
        }


    }

    public void Clicked()
    {
        if (clickIndex + (8 - (currentElement)) < crackList.Count - 1)
        {
            clickIndex += (8 - (currentElement));
            crackObject.GetComponent<Image>().sprite = crackList[clickIndex];
        }
        else
            NewElement();

        
    }
}
