using System.Collections;
using UnityEngine;

public class RoadColorController : MonoBehaviour
{
    public float roadColorChangeRate;
    private float currentRoadColor; 

    private Transform cameraPos;
    private Player player;
    private Battery battery; 
    private SpriteRenderer leftLane;
    private SpriteRenderer rightLane;
    private SpriteRenderer upperLanes;

    void Start()
    {
        currentRoadColor = Colors.StartingRoadColor; 

        cameraPos = GameObject.Find("GameCamera").transform; 
        player = GameObject.Find("Player").GetComponent<Player>();
        battery = player.getPlayerBattery(); 
        leftLane = transform.Find("LeftLane").GetComponent<SpriteRenderer>();
        rightLane = transform.Find("RightLane").GetComponent<SpriteRenderer>();
        upperLanes = transform.Find("UpperLanes").GetComponent<SpriteRenderer>();

        leftLane.color = Colors.rgbToColor(Colors.StartingRoadColor);
        rightLane.color = Colors.rgbToColor(Colors.StartingRoadColor);
        upperLanes.color = Colors.makeAlphaZero(Color.white);
    }

    void Update()
    {
        if (currentRoadColor > 0)
        {
            currentRoadColor -= roadColorChangeRate * Time.deltaTime;
        }

        transform.position = new Vector3(cameraPos.position.x,transform.position.y,transform.position.z);

        if (player.getSlowMotionStatus())
        {
            leftLane.color = Colors.SlowMotionClover;
            rightLane.color = Colors.SlowMotionClover;
        } else
        {
            if (player.getPlayerVehicle().getLaneIndex() > 1)
            {
                leftLane.color = battery.currentBatteryColor(true);
            }
            else
            {
                leftLane.color = Colors.rgbToColor(currentRoadColor);
            }

            rightLane.color = Colors.rgbToColor(currentRoadColor);
        }
    }

    public void showUpperLanes(Color lanesColor)
    {
        upperLanes.color = lanesColor; 
        upperLanes.color = Colors.makeAlphaOne(upperLanes.color);
    }

    public void fadeOutUpperLanes()
    {
        StartCoroutine(fadeOutUpperLanesCR());
    }

    private IEnumerator fadeOutUpperLanesCR()
    {
        for (float alpha = 1; alpha >= 0; alpha -= 0.03f)
        {
            upperLanes.color = new Color(upperLanes.color.r, upperLanes.color.g, upperLanes.color.b, alpha);
            yield return null;
        }
        upperLanes.color = new Color(upperLanes.color.r, upperLanes.color.g, upperLanes.color.b, 0);
    }

    public Color currentTrafficColor()
    {
        if (currentRoadColor >= 106.5f)
        {
            return Color.black;
        }
        else
        {
            return Color.white;
        }
    }

    public Color currentCarColor()
    {
        if (currentRoadColor >= 106.5f)
        {
            return Color.white;
        }
        else
        {
            return Colors.CarFinalColor;
        }
    }
}
