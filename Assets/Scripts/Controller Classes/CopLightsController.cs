using UnityEngine;

public class CopLightsController : MonoBehaviour
{
    public float treshold;
    public float lightsInterval;

    private SpriteRenderer leftCopLane;
    private SpriteRenderer rightCopLane;
    private float lastTime; 
    private Cop cop;
    private Vector3 initialPosition;
    private float cameraWidth; 

    void Start()
    {
        leftCopLane = transform.Find("CopLeftLane").GetComponent<SpriteRenderer>();
        rightCopLane = transform.Find("CopRightLane").GetComponent<SpriteRenderer>();

        lastTime = Time.time; 
        cop = GameObject.Find("Cop").GetComponent<Cop>();
        initialPosition = transform.localPosition; 
        cameraWidth = GameObject.Find("GameCamera").GetComponent<GameCamera>().CameraWidth;
    }

    void Update()
    {
        transform.localPosition = addXToPosition(roadToCover() * cameraWidth);

        if ((Time.time - lastTime) > lightsInterval)
        {
            toggleLights(); 
            lastTime = Time.time; 
        }
    }

    private float roadToCover()
    {
        if (cop.distanceToPlayer() < treshold)
        {
            return ((treshold - cop.distanceToPlayer()) / treshold) + 0.03f;
        } else
        {
            return 0; 
        }
    }

    private Vector3 addXToPosition(float xValue)
    {
        return new Vector3(initialPosition.x + xValue, initialPosition.y, initialPosition.z); 
    }

    private void toggleLights()
    {
        if (leftCopLane.color == Colors.CopRed)
        {
            leftCopLane.color = Colors.CopBlue;
            rightCopLane.color = Colors.CopRed;
        } else
        {
            leftCopLane.color = Colors.CopRed;
            rightCopLane.color = Colors.CopBlue;
        }

    }
}
