using System.Collections;
using UnityEngine;

public class PlayerCircle : MonoBehaviour
{
    private SpriteRenderer circleColor; 

    private void Start()
    {
        circleColor = GetComponent<SpriteRenderer>(); 
    }

    public void toggleCircle(bool start, Color color)
    {
        circleColor.color = color; 
        
        if (start)
        {
            StartCoroutine(expandCircleCR());
        }
        else
        {
            transform.localScale = Vector3.zero;
            StopCoroutine(expandCircleCR());   
        }
    }

    private IEnumerator expandCircleCR()
    {
        for (float i = 0; i < 35; i += 1f)
        {
            transform.localScale = new Vector3(i, i, 0);
            yield return new WaitForSecondsRealtime(0.001f);
        }
    }
}