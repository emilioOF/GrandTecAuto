using UnityEngine;

public class Score
{
    private Transform playerPos; 
    private float initialXPos;
    private float initialTime;

    public Score(Transform playerPos)
    {
        this.playerPos = playerPos; 
        initialXPos = playerPos.position.x;
        initialTime = Time.time; 
    }

    public float getScore()
    {
        return (playerPos.position.x - initialXPos) * 0.2f; 
    }

    public float getTime()
    {
        return Time.time - initialTime; 
    }

}
