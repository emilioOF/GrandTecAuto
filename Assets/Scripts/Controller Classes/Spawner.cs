using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] bots; 
    public float spawnRate;

    private float lastPosX;
    private Chooser chooser; 

    // Start is called before the first frame update
    void Start()
    {
        lastPosX = transform.position.x;
        chooser = new Chooser(new int[] {0,1,2,3}); 
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - lastPosX) > spawnRate)
        {
            createBot();
            lastPosX = transform.position.x; 
        }
    }

    private void createBot()
    {
        Instantiate(bots[chooser.choose()], transform.position, transform.rotation);
    }
}