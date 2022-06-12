using System.Collections;
using UnityEngine;
using UnityEngine.UI; 

public class UIController : MonoBehaviour
{
    private Player player; 
    private Vehicle vehicle; 
    private Battery battery;

    private Transform velocityBar;
    private SpriteRenderer velocityBarFill; 
    private Transform energyBar;
    private SpriteRenderer energyBarFill;

    private Transform ui; 
    private Text scoreValue;
    private Text timeValue; 

    private Transform expandingCircleCrash;
    private Transform expandingCircleCaught; 

    private float cameraWidth;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>(); 
        vehicle = player.getPlayerVehicle(); 
        battery = player.getPlayerBattery();

        velocityBar = GameObject.Find("VelocityBar").transform;
        velocityBarFill = velocityBar.Find("VelocityBarFill").GetComponent<SpriteRenderer>(); 
        energyBar = GameObject.Find("EnergyBar").transform;
        energyBarFill = energyBar.Find("EnergyBarFill").GetComponent<SpriteRenderer>();

        ui = GameObject.Find("UI").transform; 
        scoreValue = transform.Find("ScoreValue").GetComponent<Text>();
        timeValue = transform.Find("TimeValue").GetComponent<Text>();

        ui.localPosition = new Vector3(ui.localPosition.x, ui.localPosition.y, 9.8f); 

        expandingCircleCrash = GameObject.Find("ExpandingCircleCrash").transform;
        expandingCircleCaught = GameObject.Find("ExpandingCircleCaught").transform;

        expandingCircleCrash.GetComponent<SpriteRenderer>().color = Colors.Grape;
        expandingCircleCaught.GetComponent<SpriteRenderer>().color = Colors.Grape;
        expandingCircleCrash.localScale = Vector3.zero;
        expandingCircleCaught.localScale = Vector3.zero;

        cameraWidth = GameObject.Find("GameCamera").GetComponent<GameCamera>().CameraWidth;

        toggleUiElements(false);
    }

    void Update()
    {
        if (!GameController.GameStopped)
        {
            scoreValue.text = toString(player.getScore());
            controlVelocityBar();
            controlEnergyBar();
        }     
    }

    private string toString(float value, string format)
    {
        return value.ToString(format);
    }

    private string toString(float value)
    {
        int intValue = (int)value; 
        return intValue.ToString();
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

    public void changeTextColor()
    {
        StartCoroutine(changeTextColorCR()); 
    }

    private IEnumerator changeTextColorCR()
    {
        scoreValue.color = Colors.SkyBlue;
        yield return new WaitForSeconds(0.5f);
        scoreValue.color = Color.white; 
    }

    public void endGameUI(string lossCause)
    {
        expandCircle(lossCause); 

        ui.localPosition = new Vector3(ui.localPosition.x, ui.localPosition.y, 8f);

        scoreValue.text = toString(FinalScoreTime.FinalScore, "0.00");
        timeValue.text = toString(FinalScoreTime.FinalTime, "0.00");

        toggleUiElements(true);
    }

    public void toggleUiElements(bool state)
    {
        ui.transform.Find("ScoreTitle").gameObject.SetActive(state);
        ui.transform.Find("TimeTitle").gameObject.SetActive(state);
        timeValue.gameObject.SetActive(state);
    }

    public void expandCircle(string circle)
    {
        if (circle == "crash")
        {
            StartCoroutine(expandCircleCR(expandingCircleCrash));
        } else if (circle == "caught")
        {
            StartCoroutine(expandCircleCR(expandingCircleCaught)); 
        }
    }

    private IEnumerator expandCircleCR(Transform circleTransform)
    {
        for (float i = 0; i < 50; i += 1.5f)
        {
            circleTransform.localScale = new Vector3(i, i, 0);
            yield return null;
        }
    }
}
