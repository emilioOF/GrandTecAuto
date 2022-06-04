using System.Collections;
using UnityEngine;

public class PlayerCircle : MonoBehaviour
{

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Colors.SlowMotionClover; 
    }

    public void expandCircle(bool start)
    {
        if (start)
        {
            StartCoroutine(expandCircleCR());
        }
        else
        {
            StopCoroutine(expandCircleCR());
            transform.localScale = Vector3.zero;
        }
    }

    private IEnumerator expandCircleCR()
    {
        for (float i = 0; i < 40; i += 1f)
        {
            transform.localScale = new Vector3(i, i, 0);
            yield return new WaitForSecondsRealtime(0.001f);
        }
    }
}