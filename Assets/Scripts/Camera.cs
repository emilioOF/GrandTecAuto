using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform playerTran; 

    void Start()
    {
        playerTran = GameObject.Find("Player").transform; 
    }

    void Update()
    {
        transform.position = new Vector3(playerTran.position.x, 0, -10); 
    }
}
