using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerController playerController;

    [System.Obsolete]
    private void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerController.Die();
        }
    }
}
