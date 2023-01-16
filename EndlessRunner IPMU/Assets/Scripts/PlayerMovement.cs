using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public float horizontalMult = 1.5f;
    TextMeshProUGUI finalDistance;
    GameObject panel;
    [SerializeField] GameObject manager;

    void Awake()
    {
        controls = new PlayerInputActions();
       
    }

    void FixedUpdate()
    {
        if(!alive){
            return;
        }
        speed += 0.001f;
        Vector3 forwardMov = transform.forward * speed * Time.fixedDeltaTime;



        if (rb.position.x <= -5 && horizontalInput < 0)
        {
            horizontalInput = 0;
        }
        else if (rb.position.x >= 5 && horizontalInput > 0)
        {
            horizontalInput = 0;
        }

        Vector3 horizontalMov = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMult;

        rb.MovePosition(rb.position + forwardMov + horizontalMov);
        //speed += acceleration;

        //Vector3 forwardMov = transform.forward * speed * Time.fixedDeltaTime;
        //Vector3 horizontalMov = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMult;
        //rb.MovePosition(rb.position + forwardMov + horizontalMov);
        //speed += acceleration;
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        /*if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }*/

        if(Input.GetButton("Jump") && IsGrounded()){
            Jump();
        }

        if(transform.position.y < -5){
            Death();
        }
    }

    public bool IsGrounded()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        return isGrounded;
    }

    public void Death(){
        alive = false;
        Invoke("RestartGame", 2);
    }

    void RestartGame(){
        //finalDistance.text = "Your Score:" + manager.score; 
        //panel.SetActive(true);
        SceneManager.LoadScene("GameOver");
    }
    void Jump(){
        //float height = GetComponent<Collider>().bounds.size.y;
        //bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        //if(isGrounded){
        if(rb.position.y>0&& rb.position.y<50)
            rb.AddForce(Vector3.up * jumpForce);
        //}
        
    }
}
