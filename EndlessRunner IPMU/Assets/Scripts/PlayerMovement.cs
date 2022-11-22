
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask groundMask;


    bool alive = true;
    public float speed = 5f;
    public float acceleration = 0.05f;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMult = 2f;

    [SerializeField] 
    public float jumpForce = 600f;
    



    void FixedUpdate()
    {
        if (!alive) {
            return;
        }
        Vector3 forwardMov = transform.forward * speed * Time.fixedDeltaTime;
        
        
   
        if(rb.position.x <= -5 && horizontalInput < 0)
        {
            horizontalInput = 0;
        }
        else if(rb.position.x >= 5 && horizontalInput > 0)
        {
            horizontalInput = 0;
        }

        Vector3 horizontalMov = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMult;

        rb.MovePosition(rb.position + forwardMov + horizontalMov);
        //speed += acceleration;
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
            Jump();
        }

        if (transform.position.y < -5) {
            Death();
        }
    }

    public bool IsGrounded() {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
       
        return isGrounded;
    }

    public void Death(){
        alive = false;
        Invoke("RestartGame", 2);
    }

    void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Jump(){
       
        rb.AddForce(Vector3.up * jumpForce);
    }
}
