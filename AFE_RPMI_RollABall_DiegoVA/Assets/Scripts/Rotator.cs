using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 lastPosition = Vector3.zero;
    [SerializeField]
    private float radius = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
        lastPosition = transform.position; 
    }

    void RotateObject()
    {
        float circumference = Mathf.PI * radius;
        Vector3 displacement = transform.position - lastPosition;
        Vector3 rotationDelta = displacement * (180 / circumference);
        transform.Rotate(new Vector3(rotationDelta.z, 0, 0));
        Debug.Log(displacement);
        Debug.Log(transform.position);
    }
}
