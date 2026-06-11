using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool alive = true;

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


    [Header("Sound Configuration")]
    public AudioClip[] soundCollection;

    void Start()
    {
        
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
      
    }

    private void FixedUpdate()
    {
        if (!alive) return;

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
            Die();
        }
    }

    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        PlaySFX(0);
    }

    
    public void PlaySFX(int soundToPlay)
    {
        playerAudio.PlayOneShot(soundCollection[soundToPlay]);
    }

    public void Die()
    {
        alive = false;
        GameManager.Instance.EndGame();
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
