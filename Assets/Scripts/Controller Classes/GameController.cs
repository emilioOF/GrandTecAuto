using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static private float[] lanes = { -4.0f, -1.4f, 1.47f, 4.0f };

    static public float[] Lanes
    {
        get { return lanes; }
    }

    static public void endGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
