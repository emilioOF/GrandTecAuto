using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public float colorChangeRate; 

    private Transform cameraPos;
    private Player player;
    private Transform playerCircle; 
    private Cop cop;
    private SpriteRenderer leftLane;
    private SpriteRenderer rightLane;

    private Transform copLanesPos;
    private SpriteRenderer copLeftLane;
    private SpriteRenderer copRightLane;

    private readonly int[] copRed = { 237, 35, 13 };
    private readonly int[] copBlue = { 2, 118, 186 };
    private readonly int[] electricYellow = { 255, 218, 51 };
    private readonly int[] electricBlue = { 0, 161, 255 };
    private readonly int[] darkElectricBlue = { 0, 83, 147 };
    private readonly int[] slowMotionTangerine = { 255, 147, 0 };
    private float currentRoadColor;
    private float remainingBattery; 

    void Start()
    {
        cameraPos = GameObject.Find("GameCamera").transform; 
        player = GameObject.Find("Player").GetComponent<Player>();
        playerCircle = GameObject.Find("PlayerCircle").transform; 
        cop = GameObject.Find("Cop").GetComponent<Cop>();
        leftLane = transform.Find("LeftLane").GetComponent<SpriteRenderer>();
        rightLane = transform.Find("RightLane").GetComponent<SpriteRenderer>();

        copLanesPos = transform.Find("CopLanes");
        copLeftLane = copLanesPos.Find("CopLeftLane").GetComponent<SpriteRenderer>();
        copRightLane = copLanesPos.Find("CopRightLane").GetComponent<SpriteRenderer>();

        currentRoadColor = 213;
        remainingBattery = 100; 

        leftLane.color = rgbToColor(currentRoadColor);
        rightLane.color = rgbToColor(currentRoadColor);
        copLeftLane.color = rgbToColor(copRed);
        copRightLane.color = rgbToColor(copBlue); 
    }

    void Update()
    {
        remainingBattery = player.getPlayerBattery().currentBattery();

        transform.position = new Vector3(cameraPos.position.x,transform.position.y,transform.position.z);

        if (currentRoadColor > 0)
        {
            currentRoadColor -= colorChangeRate * Time.deltaTime;
        }

        rightLane.color = rgbToColor(currentRoadColor);

        if (player.getPlayerVehicle().getLaneIndex() > 1)
        {
            if (remainingBattery > 30 && remainingBattery < 100)
            {
                leftLane.color = rgbToColor(electricBlue);
            }
            else if (remainingBattery <= 30)
            {
                leftLane.color = rgbToColor(electricYellow);
            }
            else
            {
                leftLane.color = rgbToColor(darkElectricBlue);
            }
        }
        else
        {
            leftLane.color = rgbToColor(currentRoadColor);
        }

    }

    private Color rgbToColor(int[] rgb)
    {
        float a = rgb[0]/255.0f;
        float b = rgb[1]/255.0f;
        float c = rgb[2]/255.0f;

        return new Color(a, b, c); 
    }

    private Color rgbToColor(float colorValue)
    {
        float nColorValue = colorValue / 255; 
        return new Color(nColorValue, nColorValue, nColorValue);
    }

    public Color currentCarColor()
    {
        if (currentRoadColor >= 106.5)
        {
            return new Color(0,0,0); 
        } else
        {
            return new Color(1, 1, 1);
        }
    }

    public void slowMoAnimation(bool start)
    {
        if (start)
        {
            StartCoroutine(slowMoAnimationCR());
        } else
        {
            StopCoroutine(slowMoAnimationCR());
            playerCircle.localScale = Vector3.zero;
        }
    }

    public IEnumerator slowMoAnimationCR()
    {
        for (float i = 0; i < 50; i += 1f)
        {
            playerCircle.localScale = new Vector3(i, i, 0);
            yield return new WaitForSecondsRealtime(0.001f);
        }
    }
}
