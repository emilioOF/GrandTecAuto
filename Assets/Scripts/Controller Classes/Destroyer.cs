using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string objectTag = collision.gameObject.tag; 
        if (objectTag == "bot" || objectTag == "botEnergy" || objectTag == "copText")
        {
            Destroy(collision.gameObject);
        }
    }
}
