using System.Collections.Generic; 
using UnityEngine;

public class Chooser
{
    private List<int> indexes;
    private int indexesLength;

    public Chooser(int[] weighs)
    {
        indexes = new List<int>();

        for (int i = 0; i < weighs.Length; i++)
        {
            for (int z = 0; z < weighs[i]; z++)
            {
                indexes.Add(i);
            }
        }

        indexesLength = indexes.Count;
    }

    public int choose()
    {
        return indexes[Random.Range(0, indexesLength - 1)]; ; 
    }
}
