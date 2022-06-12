public class FinalScoreTime
{
    static private bool captured = false;
    static private float finalScore = 0;
    static private float finalTime = 0; 

    static public float FinalScore
    {
        get { return finalScore;  }
    }

    static public float FinalTime
    {
        get { return finalTime; }
    }

    static public bool Captured
    {
        get { return captured; }
    }

    static public void captureScoreTime(float score, float time)
    {
        if (!captured)
        {
            finalScore = score;
            finalTime = time;
            captured = true;
        }
    }

    static public void resetFinalScoreTime()
    {
        finalScore = 0;
        finalTime = 0;
        captured = false;
    }
}
