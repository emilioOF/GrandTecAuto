using UnityEngine;

public class Chooser
{
    private int[] arr;
    private int arrSize; 

    public Chooser(int[] arr)
    {
        this.arr = arr;
        arrSize = arr.Length; 
    }

    public int choose()
    {
        swap(Random.Range(0, arrSize - 1), arrSize - 1);
        return arr[arrSize - 1]; 
    }

    private void swap(int indexA, int indexB)
    {
        int aux = arr[indexA];
        arr[indexA] = arr[indexB];
        arr[indexB] = aux; 
    }
}
