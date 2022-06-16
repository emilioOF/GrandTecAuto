using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class User : MonoBehaviour
{
    private const string url = "http://localhost:5000/api/user";

    private bool loggedIn;

    private UsuarioJuego usuario; 

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        loggedIn = false;
        usuario = new UsuarioJuego(); 

        getUserData();
    }

    public void saveScore(float score, float time)
    {
        if (loggedIn)
        {
            StartCoroutine(saveScoreCR(scoreToJson(score, time)));
        }
    }

    public void getUserData()
    {
        if (!loggedIn)
        {
            usuario.idUsuario = 2;
            usuario.nombreUsuario = "CJ";
            loggedIn = true; 

            //StartCoroutine(getUserDataCR());
        }
    }

    public int getUserId()
    {
        return usuario.idUsuario; 
    }

    public string getUserName()
    {
        return usuario.nombreUsuario; 
    }

    public bool isLoggedIn()
    {
        return loggedIn; 
    }

    private string scoreToJson(float score, float time)
    {

        return JsonUtility.ToJson(new PartidaJuego {idUsuario = usuario.idUsuario, puntajePartida = score, duracionPartida = time }); 
    }

    //private IEnumerator saveScoreCR(string body)
    //{
    //    Debug.Log(body);
    //    using (UnityWebRequest request = UnityWebRequest.Post(url, body))
    //    {
    //        yield return request.SendWebRequest();

    //        if (request.result == UnityWebRequest.Result.Success)
    //        {
    //            Debug.Log("Saved"); 
    //        } else
    //        {
    //            Debug.Log("Saving failed"); 
    //        }
    //    }
    //}

    private IEnumerator saveScoreCR(string body)
    {
        //Debug.Log(body); 
        var req = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(body);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return req.SendWebRequest(); 

        if (req.result == UnityWebRequest.Result.Success)
        {
            //Debug.Log("Received: " + req.downloadHandler.text);
        }
        else
        {
            //Debug.Log("Error While Sending: " + req.error);
        }

    }

    private IEnumerator getUserDataCR()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                loggedIn = true;
                string text = request.downloadHandler.text; 
                usuario = JsonUtility.FromJson<UsuarioJuego>(text);
            } else
            {
                loggedIn = false; 
                //Debug.Log("Getting user data failed"); 
            }
        }
    }
}

