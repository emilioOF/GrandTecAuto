using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIController : MonoBehaviour
{
    private Cop cop;
    private Text disCopPlayer; 

    // Start is called before the first frame update
    void Start()
    {
        cop = GameObject.Find("Cop").GetComponent<Cop>(); 
        disCopPlayer = transform.Find("DisCopPlayer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        disCopPlayer.text = cop.distanceToPlayerStr(); 
    }
}
