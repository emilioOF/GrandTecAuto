using UnityEngine;
using UnityEngine.UI; 

public class UIController : MonoBehaviour
{
    private Vehicle vehicle; 
    private Battery battery;
    private Transform velocityBar;
    private SpriteRenderer velocityBarFill; 
    private Transform energyBar;
    private SpriteRenderer energyBarFill;
    private Score score; 
    private float cameraWidth; 

    void Start()
    {
        vehicle = GameObject.Find("Player").GetComponent<Player>().getPlayerVehicle(); 
        battery = GameObject.Find("Player").GetComponent<Player>().getPlayerBattery();
        velocityBar = GameObject.Find("VelocityBar").transform;
        velocityBarFill = velocityBar.Find("VelocityBarFill").GetComponent<SpriteRenderer>(); 
        energyBar = GameObject.Find("EnergyBar").transform;
        energyBarFill = energyBar.Find("EnergyBarFill").GetComponent<SpriteRenderer>();

        score = new Score(GameObject.Find("Player").transform); 

        cameraWidth = GameObject.Find("GameCamera").GetComponent<GameCamera>().CameraWidth; 
    }

    void Update()
    {
        controlVelocityBar(); 
        controlEnergyBar();
    }

    private string toString(float value)
    {
        int valueInt = (int)value;
        return valueInt.ToString(); 
    }

    private string toString(int value)
    {
        return value.ToString();
    }

    private void controlVelocityBar()
    {
        float speedIndex = (float)vehicle.getSpeedIndex();
        float numSpeeds = (float)vehicle.numSpeeds();
        velocityBar.localScale = new Vector3(cameraWidth * ((speedIndex + 1)/numSpeeds), 1, 0); 
    }

    private void controlEnergyBar()
    {
        energyBarFill.color = battery.currentBatteryColor(false);   
        energyBar.localScale = new Vector3(cameraWidth * (battery.currentBattery()/100), 1, 0); 
    }
}
