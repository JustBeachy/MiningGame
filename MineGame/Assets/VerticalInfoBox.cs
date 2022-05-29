using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalInfoBox : MonoBehaviour
{
    public GameObject cantCraftScreen;
    public GameObject button, onOffButton;
    public Text title, desc;
    public Image img;
    public Image[] craftingRequirements;
    GameObject originObject;
    // Start is called before the first frame update
    void Start()
    {
        if (originObject.name.Contains("Press") && originObject.GetComponent<Craftable>().crafted)
        {
            onOffButton.SetActive(true);
            if (StaticVars.PressOn)
                onOffButton.GetComponentInChildren<Text>().text = "Turn Off";
            else
                onOffButton.GetComponentInChildren<Text>().text = "Turn On";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            Destroy(gameObject);
    }

    public void SetInfo(string t, string d, Sprite i,int q, Sprite[] comps, int[] compquant, GameObject o)
    {
        if (q > 0)
            title.text = t + " (" + q + ")";
        else
            title.text = t;
        desc.text = d;
        img.sprite = i;
        originObject = o;


        if (o.GetComponent<Craftable>().crafted && !o.GetComponent<Craftable>().canCraftMultiple)
        {
            Destroy(button);
            craftingRequirements[0].gameObject.GetComponentInChildren<Text>().text = "This item can only be crafted once and has already been crafted";
            craftingRequirements[0].gameObject.GetComponentInChildren<Text>().color = Color.red;
        }
        else
        {
            for (int p = 0; p < comps.Length; p++)
            {
                craftingRequirements[p].sprite = comps[p];
                craftingRequirements[p].gameObject.GetComponentInChildren<Text>().text = compquant[p].ToString();
            }
        }

        

    }

    public void PressOnOff()
    {
        StaticVars.PressOn = !StaticVars.PressOn;

        if (StaticVars.PressOn)
            originObject.GetComponent<Image>().sprite = originObject.GetComponent<Craftable>().onSprite;
        else
            originObject.GetComponent<Image>().sprite = originObject.GetComponent<Craftable>().offSpritePress;
    }

    public void TryToCraft()
    {
        originObject.GetComponent<Craftable>().Craft();
        if (!originObject.GetComponent<Craftable>().crafted)
            Instantiate(cantCraftScreen, transform.parent);
    }
}
