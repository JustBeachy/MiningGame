using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalInfoBox : MonoBehaviour
{
    public Text title, desc;
    public Image img;
    public Image[] craftingRequirements;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            Destroy(gameObject);
    }

    public void SetInfo(string t, string d, Sprite i,int q, Sprite[] comps, int[] compquant)
    {
        if (q > 0)
            title.text = t + " (" + q + ")";
        else
            title.text = t;
        desc.text = d;
        img.sprite = i;

        for(int p = 0;p < comps.Length;p++)
        {
            craftingRequirements[p].sprite = comps[p];
            craftingRequirements[p].gameObject.GetComponentInChildren<Text>().text = compquant[p].ToString();
        }

    }
}
