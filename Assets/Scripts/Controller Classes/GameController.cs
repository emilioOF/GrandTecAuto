using UnityEngine; 
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static private float[] lanes = { -3.4f, -1f, 1.6f, 4.0f };
    static private float trafficSpeedMaster = 1f;
    static private float playerSpeedMaster = 1f;
    static private bool gameStopped = false;

    static public float[] Lanes
    {
        get { return lanes; }
    }

    static public float TrafficSpeedMaster
    {
        get { return trafficSpeedMaster; }
        set { trafficSpeedMaster = value; }
    }

    static public float PlayerSpeedMaster
    {
        get { return playerSpeedMaster; }
        set { playerSpeedMaster = value; }
    }

    static public bool GameStopped
    {
        get { return gameStopped; }
    }

    static public void endGameGC()
    {
        Time.timeScale = 0; 
        playerSpeedMaster = 0f;
        trafficSpeedMaster = 0f;
        gameStopped = true;
    }

    static public void restartGame()
    {
        resetMembers();
        FinalScoreTime.resetFinalScoreTime(); 
        SceneManager.LoadScene("PlayScene");
    }

    static private void resetMembers()
    {
        Time.timeScale = 1; 
        trafficSpeedMaster = 1;
        playerSpeedMaster = 1;
        gameStopped = false; 
    }
}
