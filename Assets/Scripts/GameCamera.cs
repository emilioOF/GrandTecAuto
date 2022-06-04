using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public float offSet;
    private Transform playerTran;
    private float cameraWidth;

    private void Awake()
    {
        float cameraHeight = GetComponent<Camera>().orthographicSize * 2;
        float cameraAspect = GetComponent<Camera>().aspect;
        cameraWidth = cameraHeight * cameraAspect;
    }

    void Start()
    {
        playerTran = GameObject.Find("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(playerTran.position.x + offSet, 0, -10); 
    }

    public float CameraWidth
    {
        get { return cameraWidth; }
    }
}
