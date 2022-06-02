using UnityEngine; 
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static private float[] lanes = { -3.4f, -1f, 1.6f, 4.0f };
    static private float speedMaster = 1f;

    static public float[] Lanes
    {
        get { return lanes; }
    }

    static public float SpeedMaster
    {
        get { return speedMaster; }
        set { speedMaster = value; }
    }

    static public void endGame()
    {
        resetMembers(); 
        SceneManager.LoadScene("PlayScene");
    }

    static private void resetMembers()
    {
        speedMaster = 1; 
    }
}
