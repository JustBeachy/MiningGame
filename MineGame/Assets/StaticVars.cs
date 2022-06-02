using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticVars : MonoBehaviour
{
    // Start is called before the first frame update
    public static int mineralMineMultiplier = 1;
    public static int topsoilMineMultiplier = 1;
    public static float EnergyProduction = 0;
    public static bool FurnaceOn = false;
    public static bool PressOn = false;
    public static bool DiggerOn = false;
    public static bool MinerOn = false;
    public static bool HideParticles = false;
    public Text EnergyText;
    public Text Timer;
    public GameObject topsoilLayer, mineralLayer;
    public static float time=-1;
    float mineTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time>-1)
        time += Time.deltaTime;

        Timer.text = "Time: " + time.ToString("0");

        if(MinerOn||DiggerOn)
        mineTimer += Time.deltaTime;

        if (EnergyProduction > 0 && mineTimer > (1 / EnergyProduction))
        {
            if (MinerOn)
                mineralLayer.GetComponent<Elements>().Clicked();
            if (DiggerOn)
                topsoilLayer.GetComponent<Elements>().Clicked();

            mineTimer = 0;
        }
    }

    public void UpdateText()
    {
        if(EnergyProduction!=0)
        EnergyText.text = EnergyProduction.ToString()+" C/S";
    }
}
