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

    public Sprite restartIcon;
    public Sprite doneIcon; 

    private SpriteRenderer background;
    private SpriteRenderer leftCopLight;
    private SpriteRenderer rightCopLight;
    private float currentRoadColor; 
    private float lastTime;

    private User user; 

    private GameObject playButton;
    private GameObject userButton;
    private Text userStatusText; 

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

        user = GameObject.Find("User").GetComponent<User>(); 

        playButton = GameObject.Find("PlayButton");
        playButton.GetComponent<Button>().onClick.AddListener(startGame);
        userButton = GameObject.Find("UserButton");
        userButton.GetComponent<Button>().onClick.AddListener(user.getUserData);
        userStatusText = GameObject.Find("UserStatusText").GetComponent<Text>();

        configurePlayButton(Colors.rgbToColor(183), "Cargando ...");
        configureUserButton(Color.white, restartIcon, true);
        userStatusText.text = "Sin Sesión";
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
            configurePlayButton(Color.white, "Jugar");
            doneLoading = true; 
        }

        if (user.isLoggedIn())
        {
            configureUserButton(Colors.LightGreen, doneIcon, false);
            userStatusText.text = user.getUserName();
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

    private void configurePlayButton(Color color, string text)
    {
        playButton.GetComponent<Image>().color = color;
        playButton.transform.Find("PlayButtonText").GetComponent<Text>().text = text;
    }

    private void configureUserButton(Color color, Sprite sprite, bool isInteractable)
    {
        userButton.GetComponent<Image>().sprite = sprite;
        userButton.GetComponent<Image>().color = color;
        userButton.GetComponent<Button>().interactable = isInteractable; 
    }

    private void startGame()
    {
        if (doneLoading)
        {
            asyncOperation.allowSceneActivation = true; 
        }
    }
}
