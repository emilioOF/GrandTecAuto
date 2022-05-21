using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] bots; 
    public float disInterval;

    private float lastXPos; 

    // Start is called before the first frame update
    void Start()
    {
        lastXPos = transform.position.x; 
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - lastXPos) > disInterval)
        {
            createBot();
            lastXPos = transform.position.x; 
        }
    }

    private void createBot()
    {
        Instantiate(bots[randomBotIndex()], transform.position, transform.rotation);
    }

    private bool randomBool()
    {
        return Random.value < 0.5; 
    }

    private int randomBotIndex()
    {
        if (randomBool())
        {
            if (randomBool())
            {
                return 0; 
            }
            else
            {
                return 1; 
            }
        }
        else
        {
            if (randomBool())
            {
                return 2;
            }
            else
            {
                return 3; 
            }
        }
    }
}