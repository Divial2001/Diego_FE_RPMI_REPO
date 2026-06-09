using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    [SerializeField]
    private float acceleration = 0.1f;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    [Header("Editor References")]
    public Rigidbody playerRb; 
    public AudioSource playerAudio; 

    [Header("Jump Parameters")]
    public float jumpForce = 6;
    public bool isGrounded = true;

    [Header("Respawn System")]
    public float fallLimit = -10;
    public Transform respawnPoint;

    [Header("Sound Configuration")]
    public AudioClip[] soundCollection;

    void Start()
    {
        
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y <= fallLimit)
        {
            Respawn();
        }
    }

    private void FixedUpdate()
    {
        speed += acceleration * Time.fixedDeltaTime;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        playerRb.MovePosition(playerRb.position + forwardMove + horizontalMove); 
    }

    
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Respawn();
        }
    }



    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        PlaySFX(0);
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
        playerRb.linearVelocity = new Vector3(0,0,0);
        PlaySFX(2);
    }

    public void PlaySFX(int soundToPlay)
    {
        playerAudio.PlayOneShot(soundCollection[soundToPlay]);
    }

    #region Input Methods

   

    public void OnJump(InputAction.CallbackContext context) 
    {

        if (context.performed && isGrounded == true)
        {
            isGrounded = false;
            Jump();
        }
    }




    #endregion
}
