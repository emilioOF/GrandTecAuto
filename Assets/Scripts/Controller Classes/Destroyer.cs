using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bot" || collision.gameObject.tag == "botEnergy")
        {
            Destroy(collision.gameObject);
        }
    }
}
