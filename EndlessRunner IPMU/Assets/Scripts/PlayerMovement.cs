using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputActions controls;
    public LayerMask groundMask;
    public float jumpForce = 400f;
    bool alive = true;
    public float speed = 5f;
    public float acceleration = 0.05f;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMult = 2f;

    void Awake()
    {
        controls = new PlayerInputActions();
    }

    void FixedUpdate()
    {
        if(!alive){
            return;
        }
        Vector3 forwardMov = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMov = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMult;
        rb.MovePosition(rb.position + forwardMov + horizontalMov);
        //speed += acceleration;
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }

        if(Input.GetAxis("Vertical") > 0 && Input.GetAxis("Vertical") < 0.5 ){
            Jump();
        }

        if(transform.position.y < -5){
            Death();
        }
    }
    public void Death(){
        alive = false;
        Invoke("RestartGame", 2);
    }

    void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Jump(){
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        if(isGrounded){
            rb.AddForce(Vector3.up * jumpForce);
        }
        
    }
}
