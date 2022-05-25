using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public int quanitity;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddOne()
    {
        quanitity++;
        GetComponent<Image>().enabled = true;
        GetComponentInChildren<Text>().text = quanitity.ToString();
    }
}
