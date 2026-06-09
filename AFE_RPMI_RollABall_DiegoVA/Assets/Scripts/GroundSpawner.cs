
using UnityEngine;
using System.Collections;

public class GroundSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] groundTiles;
    Vector3 nextSpawnPoint;


    public void SpawnTile()
    {
        int index = Random.Range(0, groundTiles.Length); 
        GameObject template = groundTiles[index];
        GameObject tile = Instantiate(template, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = tile.transform.GetChild(1).transform.position;
    }

    void Start()
    {
        for (int i =0; i < 15; i++)
        {
            SpawnTile();
        }
        
    }

   
}
