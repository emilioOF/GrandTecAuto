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

    void Start()
    {
        currentRoadColor = Colors.StartingRoadColor; 

        cameraPos = GameObject.Find("GameCamera").transform; 
        player = GameObject.Find("Player").GetComponent<Player>();
        battery = player.getPlayerBattery(); 
        leftLane = transform.Find("LeftLane").GetComponent<SpriteRenderer>();
        rightLane = transform.Find("RightLane").GetComponent<SpriteRenderer>();

        leftLane.color = Colors.rgbToColor(Colors.StartingRoadColor);
        rightLane.color = Colors.rgbToColor(Colors.StartingRoadColor);
    }

    void Update()
    {
        if (currentRoadColor > 0)
        {
            currentRoadColor -= roadColorChangeRate * Time.deltaTime;
        }

        transform.position = new Vector3(cameraPos.position.x,transform.position.y,transform.position.z);

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

    public Color currentCarColor()
    {
        return Colors.carColor(currentRoadColor); 
    }
}
