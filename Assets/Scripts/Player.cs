using System.Collections; 
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speedIndex;
    public int laneIndex;

    private Vehicle vehicle;
    private Battery battery;
    private Rigidbody2D rigVehicle;
    private SpriteRenderer carColor;
    private SpriteRenderer carFlame;
    private PlayerCircle playerCircle;
    private Cop cop;
    private RoadColorController roadColorController;
    private bool slowMotionOn;
    
    
    void Awake()
    {
        vehicle = new Vehicle(speedIndex, laneIndex);
        battery = new Battery(); 
        rigVehicle = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        carColor = GetComponent<SpriteRenderer>();
        carFlame = transform.Find("CarFlame").GetComponent<SpriteRenderer>(); 
        playerCircle = transform.Find("PlayerCircle").GetComponent<PlayerCircle>();
        cop = GameObject.Find("Cop").GetComponent<Cop>();
        roadColorController = GameObject.Find("Lanes").GetComponent<RoadColorController>();

        slowMotionOn = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!vehicle.inLastSpeed() && !vehicle.isSpeedLockOn())
            {
                StartCoroutine(carFlameAnimation()); 
            }
            vehicle.increaseSpeed();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            vehicle.decreaseSpeed();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vehicle.moveLaneUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            vehicle.moveLaneDown();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (battery.canUseElectricAttack())
            {
                electricAttack(); 
            } 
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!slowMotionOn && !vehicle.isSpeedLockOn())
            {
                startSlowMotion();
            } else
            {
                stopSlowMotion();
            }
        }

        transform.position = new Vector3(transform.position.x, vehicle.currentPositionY(), transform.position.z);

        batteryController();

        carColorController();

        speedLockController();
    }

    private void FixedUpdate()
    {
        rigVehicle.velocity = vehicle.currentSpeed(); 
    }
   
    private void electricAttack()
    {
        roadColorController.showUpperLanes(); 
        battery.strongDischarge(30f);
        cop.pushBack(10f);
        roadColorController.fadeOutUpperLanes(); 
    }

    private void startSlowMotion()
    {
        GameController.SpeedMaster = 0.2f;
        slowMotionOn = true; 
    }

    private void stopSlowMotion()
    {
        GameController.SpeedMaster = 1f;
        slowMotionOn = false; 
    }

    public bool getSlowMotionStatus()
    {
        return slowMotionOn; 
    }

    public Vehicle getPlayerVehicle()
    {
        return vehicle;
    }

    public Battery getPlayerBattery()
    {
        return battery; 
    }
   
    private IEnumerator carFlameAnimation()
    {
        for (float i = 0; i < 1; i+= 0.1f)
        {
            carFlame.color = new Color(1, 1, 1, i);
            yield return null; 
        }
        carFlame.color = new Color(1, 1, 1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bot")
        {
            GameController.endGame();
        }
        else if (collision.gameObject.tag == "botEnergy")
        {
            Destroy(collision.gameObject); 
            battery.fillBattery();
        }
    }

    private void batteryController()
    {
        if (slowMotionOn)
        {
            battery.discharge(40);
        }
        else
        {
            if (vehicle.getLaneIndex() < 2)
            {
                battery.discharge(vehicle.currentSpeedInt());
            }
            else
            {
                battery.charge(vehicle.currentSpeedInt());
            }
        }
    }

    private void carColorController()
    {
        if (battery.canUseElectricAttack())
        {
            carColor.color = Colors.SkyBlue; 
        }
        else
        {
            if (vehicle.isSpeedLockOn())
            {
                carColor.color = Colors.BatteryEndRed; 
            } else
            {
                carColor.color = Color.white; 
            }
        }
    }

    private void speedLockController()
    {
        if (battery.currentBattery() <= 0)
        {
            vehicle.toggleSpeedLock(true);
            stopSlowMotion(); 
        }

        if (vehicle.isSpeedLockOn() && battery.currentBattery() > 20)
        {
            vehicle.toggleSpeedLock(false);
        }
    }
}

// Posición en z de los elementos del juego
// -10: Camera
// -2: VelocityMeter
// -1.1: car sprites 
// -1: Player, Bots, Spawner, Destroyer, Controllers, Cop, EnergyBar, VelocityBar
// 0: Roads
// 0.5: PlayerCircle
// 0.75: Upper Lanes
// 1: CopLights
// 2: Lanes


