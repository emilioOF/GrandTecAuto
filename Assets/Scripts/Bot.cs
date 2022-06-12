using UnityEngine;

public class Bot : MonoBehaviour
{
    public float speed;
    public int laneIndex;
    public Sprite[] botSprites; 

    private Rigidbody2D rigBot;
    private SpriteRenderer botSprite;

    void Start()
    {
        rigBot = GetComponent<Rigidbody2D>(); 
        transform.position = new Vector3(transform.position.x, GameController.Lanes[laneIndex], transform.position.z);
        botSprite = transform.Find("BotLaneSprite").GetComponent<SpriteRenderer>();

        getColorType(); 
        getSprite(); 
    }

    private void FixedUpdate()
    {
        rigBot.velocity = Vector3.right * speed * GameController.TrafficSpeedMaster;
    }

    private void getColorType()
    {
        if (Random.Range(1, 26) == 1 && laneIndex < 2)
        {
            GetComponent<SpriteRenderer>().color = Colors.SkyBlue; 
            gameObject.tag = "botEnergy"; 
        } else
        {
            GetComponent<SpriteRenderer>().color = GameObject.Find("Lanes").GetComponent<RoadColorController>().currentTrafficColor();
        }
    }

    private void getSprite()
    {
        botSprite.sprite = botSprites[Random.Range(0, botSprites.Length - 1)];

        if (speed > 0)
        {
            botSprite.flipX = true; 
        }

    }
}
