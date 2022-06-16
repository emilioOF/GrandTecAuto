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
    private SpriteRenderer carSideAnimationLeft;
    private SpriteRenderer carSideAnimationRight;
    private Cop cop;
    private RoadColorController roadColorController;
    private bool slowMotionOn;
     
    private float score;
    private float finalScore; 
    private ScoreData scoreData;
    private float initialTime;
    private float finalTime;

    private UIController uIController;

    private User user;

    private bool saved; 
 
    void Awake()
    {
        vehicle = new Vehicle(speedIndex, laneIndex);
        battery = new Battery(); 
        rigVehicle = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        carColor = transform.Find("PlayerSquare").GetComponent<SpriteRenderer>();
        carFlame = transform.Find("CarFlame").GetComponent<SpriteRenderer>();
        carSideAnimationLeft = transform.Find("CarSideAnimationLeft").GetComponent<SpriteRenderer>();
        carSideAnimationRight = transform.Find("CarSideAnimationRight").GetComponent<SpriteRenderer>();
        cop = GameObject.Find("Cop").GetComponent<Cop>();
        roadColorController = GameObject.Find("Lanes").GetComponent<RoadColorController>();

        carFlame.color = Colors.makeAlphaZero(carFlame.color);
        carSideAnimationLeft.color = Colors.makeAlphaZero(carSideAnimationLeft.color);
        carSideAnimationRight.color = Colors.makeAlphaZero(carSideAnimationRight.color);

        slowMotionOn = false;

        score = 0;
        scoreData = new ScoreData(transform.position.x, 50);
        initialTime = Time.time;

        uIController = GameObject.Find("UI").GetComponent<UIController>();

        user = GameObject.Find("User").GetComponent<User>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !GameController.GameStopped)
        {
            if (!vehicle.inLastSpeed() && !vehicle.isSpeedLockOn())
            {
                StartCoroutine(carFlameAnimation()); 
            }
            vehicle.increaseSpeed();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !GameController.GameStopped)
        {
            vehicle.decreaseSpeed();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !GameController.GameStopped)
        {
            if (vehicle.getLaneIndex() < 3)
            {
                carSideAnimationRight.color = new Color(1, 1, 1, 1);
                vehicle.moveLaneUp();
                StartCoroutine(carSideAnimation(carSideAnimationRight));
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !GameController.GameStopped)
        {
            if (vehicle.getLaneIndex() > 0)
            {
                carSideAnimationLeft.color = new Color(1,1,1,1); 
                vehicle.moveLaneDown();
                StartCoroutine(carSideAnimation(carSideAnimationLeft));
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && GameController.GameStopped)
        {
            GameController.restartGame(); 
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameController.GameStopped)
        {
            if (FinalScoreTime.Captured)
            {
                if (user.isLoggedIn()) 
                {
                    user.saveScore(FinalScoreTime.FinalScore, FinalScoreTime.FinalTime);
                } else {
                    uIController.showLogInError(); 
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameController.GameStopped)
        {
            GameController.returnMenu(); 
        }

        if (Input.GetKeyDown(KeyCode.A) && !GameController.GameStopped)
        {
            if (battery.canUseElectricAttack())
            {
                if (battery.currentBattery() >= 100)
                {
                    strongElectricAttack(); 
                } else
                {
                    softElectricAttack(); 
                }
            } 
        }

        if (Input.GetKeyDown(KeyCode.S) && !GameController.GameStopped)
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
        scoreController();
    }

    private void FixedUpdate()
    {
        rigVehicle.velocity = vehicle.currentSpeed(); 
    }

    private void softElectricAttack()
    {
        roadColorController.showUpperLanes(Colors.SkyBlue);
        battery.strongDischarge(30f);
        cop.pushBack(15f);
        roadColorController.fadeOutUpperLanes();
    }

    private void strongElectricAttack()
    {
        roadColorController.showUpperLanes(Colors.ElectricDarkBlue);
        battery.strongDischarge(30f);
        cop.pushBack(45f);
        roadColorController.fadeOutUpperLanes();
    }

    private void startSlowMotion()
    {
        GameController.PlayerSpeedMaster = 0.45f;
        GameController.TrafficSpeedMaster = 0.01f;
        slowMotionOn = true; 
    }

    private void stopSlowMotion()
    {
        GameController.PlayerSpeedMaster = 1f;
        GameController.TrafficSpeedMaster = 1f;
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

    public float getScore()
    {
        return score;
    }

    private IEnumerator carFlameAnimation()
    {
        for (float i = 0; i < 1; i+= 0.07f)
        {
            carFlame.color = new Color(1, 1, 1, i);
            yield return null; 
        }
        carFlame.color = new Color(1, 1, 1, 0);
    }

    private IEnumerator carSideAnimation(SpriteRenderer side)
    {
        for (float i = 1; i > 0; i -= 0.05f)
        {
            side.color = new Color(1, 1, 1, i);
            yield return null;
        }
        side.color = new Color(1, 1, 1, 0);
    }

    private void batteryController()
    {
        if (slowMotionOn)
        {
            battery.discharge(50);
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
                carColor.color = roadColorController.currentCarColor(); 
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

    private void scoreController()
    {
        score = (transform.position.x - scoreData.InitialXposition) * 0.2f;

        if ((score - scoreData.LastScore) >= scoreData.ScoreThreshold)
        {
            scoreData.LastScore = score;
            uIController.changeTextColor();
            battery.fillBattery(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bot")
        {
            collision.gameObject.transform.Translate(Vector3.back * 0.3f);
            endGamePlayer("crash");
        }
        else if (collision.gameObject.tag == "botEnergy")
        {
            Destroy(collision.gameObject);
            battery.fillBattery();
        }
    }

    public void endGamePlayer(string lossCause)
    {
        FinalScoreTime.captureScoreTime(score, (Time.time - initialTime)/60);
        GameController.endGameGC();
        uIController.endGameUI(lossCause);
    }
}

// Posición en z de los elementos del juego
// 2: Lanes
// 1: CopLights
// 0.75: Upper Lanes
// 0.6: copText
// 0: Roads
// -0.2: UI Canvas
// -0.5: Player Side Animation
// -1: Player, Bots, Bots square, Spawner, Destroyer, Controllers, Cop, EnergyBar, VelocityBar
// -1.1: Bot car sprites 
// -1.2: Expanding circles
// -1.3: Bots (end game)
// -1.4: Bot car sprites (end game)
// -1.5: Player square
// -1.6: Player sprite, Car flame
// -2: UI Canvas (end game)
// -10: Camera