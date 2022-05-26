using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public int quanitity;
    public GameObject infoPopup;
    public string description;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().enabled = false;
        GetComponent<Button>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddOne()
    {
        quanitity++;
        GetComponent<Image>().enabled = true;
        GetComponent<Button>().enabled = true;
        GetComponentInChildren<Text>().text = quanitity.ToString();
    }

    public void Clicked()
    {
        var info = Instantiate(infoPopup, transform.parent.parent);
        info.GetComponent<InfoBox>().SetInfo(gameObject.name, description, gameObject.GetComponent<Image>().sprite,quanitity);
    }
}
