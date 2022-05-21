using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    static private float[] lanes = { -4.0f, -1.4f, 1.47f, 4.0f };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public float[] Lanes
    {
        get { return lanes; }
    }
}
