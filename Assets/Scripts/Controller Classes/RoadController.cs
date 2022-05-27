using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController: MonoBehaviour
{
    public GameObject[] roads;
    public int[] roadsAux;
    public float offSet;
    private int last; 
    private float roadWidth; 

    // Start is called before the first frame update
    void Start()
    {
        last = roads.Length - 1; 
        roadWidth = roads[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLastVisible())
        {
            moveFirst(); 
        }   
    }

    private bool isLastVisible()
    {
        return roads[roadsAux[last]].GetComponent<SpriteRenderer>().isVisible; 
    }

    private void moveFirst()
    {
        roads[roadsAux[0]].transform.Translate(Vector3.right * (roadWidth * (last+1) - offSet));
        changeOrder(); 
    }

    private void changeOrder()
    {
        for (int i = 0; i <= last; i++)
        {
            if (roadsAux[i] + 1 > last)
            {
                roadsAux[i] = 0;
            }
            else
            {
                roadsAux[i] += 1;
            }
        }
    }
}
