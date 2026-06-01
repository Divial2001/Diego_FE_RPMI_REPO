using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = player.position + offset;
    }
}
