using Unity.VisualScripting;
using UnityEngine;

public class PLayer : MonoBehaviour
{
   
    public Rigidbody2D rb;
    public float horizontal;
    public float movespeed;
    public float jumpforce;
    public bool jump = false;
    public bool isjumping = false;
    Transform scale;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.Space) && isjumping == false )
        {
            jump = true;
            animator.SetTrigger("Jump");
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * movespeed, rb.linearVelocity.y);
        if(jump == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
            jump = false;
        }
        if(horizontal>0 && rb.transform.localScale.x <0)
        {
            scale = rb.transform;
            scale.localScale = new Vector3(scale.transform.localScale.x * -1, scale.transform.localScale.y, 1);
            rb.transform.localScale = scale.localScale;
        }
        if (horizontal < 0 && rb.transform.localScale.x > 0)
        {
            scale = rb.transform;
            scale.localScale = new Vector3(scale.transform.localScale.x * -1, scale.transform.localScale.y, 1);
            rb.transform.localScale = scale.localScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isjumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.SetTrigger("Jump");
            isjumping = true;
        }
    }
}
