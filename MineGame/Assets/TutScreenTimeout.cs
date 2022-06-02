using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutScreenTimeout : MonoBehaviour
{
    public GameObject nextTutScreen;
    float timer;
    public float timeAlive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>timeAlive)
        {
            if (nextTutScreen != null)
                nextTutScreen.SetActive(true);
            else
                StaticVars.time = 0;

            Destroy(gameObject);
        }
    }
}
