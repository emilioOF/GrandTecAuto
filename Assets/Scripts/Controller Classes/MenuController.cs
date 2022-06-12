using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private AsyncOperation asyncOperation;
    private bool doneLoading; 

    public float lightsInterval;
    public float roadColorChangeRate;

    private SpriteRenderer background;
    private SpriteRenderer leftCopLight;
    private SpriteRenderer rightCopLight;
    private float currentRoadColor; 
    private float lastTime;

    private GameObject playButton; 

    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync("PlayScene");
        asyncOperation.allowSceneActivation = false;
        doneLoading = false; 

        background = GameObject.Find("BackgroundMenu").GetComponent<SpriteRenderer>();
        leftCopLight = GameObject.Find("LeftCopLightMenu").GetComponent<SpriteRenderer>();
        rightCopLight = GameObject.Find("RightCopLightMenu").GetComponent<SpriteRenderer>();

        currentRoadColor = Colors.StartingRoadColor; 
        background.color = Colors.rgbToColor(currentRoadColor);
        leftCopLight.color = Colors.CopBlue;
        rightCopLight.color = Colors.CopRed;

        lastTime = Time.time;

        playButton = GameObject.Find("PlayButton");
        playButton.GetComponent<Button>().onClick.AddListener(startGame);

        configureButton(Colors.rgbToColor(183), "Cargando ..."); 
    }

    void Update()
    {
        if (currentRoadColor > 0)
        {
            currentRoadColor -= roadColorChangeRate * Time.deltaTime;
            background.color = Colors.rgbToColor(currentRoadColor);
        }

        if ((Time.time - lastTime) > lightsInterval)
        {
            toggleLights();
            lastTime = Time.time; 
        }

        if (asyncOperation.progress >= 0.9f)
        {
            configureButton(Color.white, "Jugar");
            doneLoading = true; 
        }
    }

    private void toggleLights()
    {
        if (leftCopLight.color == Colors.CopRed)
        {
            leftCopLight.color = Colors.CopBlue;
            rightCopLight.color = Colors.CopRed;
        }
        else
        {
            leftCopLight.color = Colors.CopRed;
            rightCopLight.color = Colors.CopBlue;
        }
    }

    private void configureButton(Color color, string text)
    {
        playButton.GetComponent<Image>().color = color;
        playButton.transform.Find("PlayButtonText").GetComponent<Text>().text = text;
    }

    private void startGame()
    {
        if (doneLoading)
        {
            asyncOperation.allowSceneActivation = true; 
        }
    }
}
