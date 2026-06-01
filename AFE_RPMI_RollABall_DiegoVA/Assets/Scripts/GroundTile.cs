using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawn groundSpawner;
    private void Start()
    {
        groundSpawner = GameObject.FindFirstObjectByType<GroundSpawn>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }


    private void Update()
    {
        
    }
}
