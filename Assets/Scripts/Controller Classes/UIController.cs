using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIController : MonoBehaviour
{
    private Cop cop;
    private Battery battery; 
    private Text disCopPlayer;
    private Text batteryPlayer;

    // Start is called before the first frame update
    void Start()
    {
        cop = GameObject.Find("Cop").GetComponent<Cop>();
        battery = GameObject.Find("Player").GetComponent<Player>().getPlayerBattery();
        disCopPlayer = transform.Find("DisCopPlayer").GetComponent<Text>();
        batteryPlayer = transform.Find("BatteryPlayer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        disCopPlayer.text = floatToString(cop.distanceToPlayer());
        batteryPlayer.text = floatToString(battery.currentBattery()); 
    }

    private string floatToString(float value)
    {
        int valueInt = (int)value;
        return valueInt.ToString(); 
    }
}
