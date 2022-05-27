using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private Transform playerTran;
    public float offSet;  

    void Start()
    {
        playerTran = GameObject.Find("Player").transform; 
    }

    void Update()
    {
        transform.position = new Vector3(playerTran.position.x + offSet, 0, -10); 
    } 
}
