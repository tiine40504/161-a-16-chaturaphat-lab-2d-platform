using UnityEngine;

public class ANT : Enemy 
{

    [SerializeField]private Vector2 velocity;
    public Transform[] MovePoints;

    

    void Start()
    {
        base.Intialize(20);
        DamageHit = 20;

        velocity = new Vector2(-1, 0);
        
    }

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (velocity.x <  0 && rb.position.x <= MovePoints[0].position.x)
        {
            Flip();
        }
        
        if (velocity.x > 0 && rb.position.x >= MovePoints[1].position.x)
        {
            Flip();
        }
    }

    public void Flip()
    {
        velocity.x *= -1;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;   
        transform.localScale = theScale;
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
