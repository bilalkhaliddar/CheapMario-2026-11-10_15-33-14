using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform target;
    public float movespeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = A;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        this.transform.position = 
            Vector2.MoveTowards(this.transform.position, 
            target.transform.position, movespeed * Time.fixedDeltaTime);
        if(Mathf.Abs(this.transform.position.x - target.transform.position.x)
            < 0.1f )
        {
            if(target == A)
                target = B;
            else
                target = A;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
