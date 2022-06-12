using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class User : MonoBehaviour
{
    private const string urlGet = "https://jsonplaceholder.typicode.com/todos/1";
    private const string urlPost = "https://my-json-server.typicode.com/typicode/demo/posts";

    private bool loggedIn;

    private string userId;
    private string userName;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        loggedIn = false;

        getUserData();
    }

    public void saveScore(float score, float time)
    {
        if (loggedIn)
        {
            StartCoroutine(saveScoreCR(scoreToForm(score, time)));
        } else
        {
            Debug.Log("Not logged in"); 
        }
    }

    public void getUserData()
    {
        StartCoroutine(getUserDataCR()); 
    }

    public string getUserId()
    {
        return userId; 
    }

    public string getUserName()
    {
        return userName; 
    }

    public bool isLoggedIn()
    {
        return loggedIn;
    }

    private WWWForm scoreToForm(float score, float time)
    {
        WWWForm form = new WWWForm();
        form.AddField("puntaje", score.ToString("0.00"));
        form.AddField("tiempo", time.ToString("0.00"));
        return form; 
    }

    private IEnumerator saveScoreCR(WWWForm form)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(urlPost, form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Saved"); 
            } else
            {
                Debug.Log("Saving failed"); 
            }
        }
    }

    private IEnumerator getUserDataCR()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(urlGet))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                loggedIn = true;
                Debug.Log(request.downloadHandler.text); 
            } else
            {
                loggedIn = false;
                Debug.Log("Getting use data failed");

            }
        }
    }
}