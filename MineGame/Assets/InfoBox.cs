using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour
{
    public Text title, desc;
    public Image img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Destroy(gameObject);
    }

    public void SetInfo(string t, string d, Sprite i,int q)
    {
        title.text = t + " ("+q+")";
        desc.text = d;
        img.sprite = i;

    }
}
