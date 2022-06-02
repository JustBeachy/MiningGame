using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] InventoryArray;
    public GameObject check;

    public GameObject Tutorial1, Tutorial2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyTut1()
    {
        Destroy(Tutorial1);
        Tutorial2.SetActive(true);
    }
}
