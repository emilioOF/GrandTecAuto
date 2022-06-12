public struct ScoreData
{
    public float InitialXposition { get; set; }
    public float LastScore { get; set; }
    public float ScoreThreshold { get; set; }

    public ScoreData(float initialXposition, float scoreThreshold)
    {
        this.InitialXposition = initialXposition;
        LastScore = 0;
        this.ScoreThreshold = scoreThreshold; 
    }
}
