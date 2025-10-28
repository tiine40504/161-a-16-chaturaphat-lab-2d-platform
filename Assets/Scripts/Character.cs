using UnityEngine;

public class Character : MonoBehaviour
{

    private int health;
    public int Health { get => health; set => health = (value < 0)? 0 : value; }

    protected Animator anim;
    protected Rigidbody2D rb;

     //methods
     public void Intialize(int starthealth)
    {
        Health = starthealth;
        Debug.Log($"{this.name} initial Health: {this.Health}.");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{ this.name} took damage {damage}. Current Health {Health}");

        IsDead();
    }

    public bool IsDead()
    {
        if(Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead and destroy");
            return true;
        }
        else
        {
            return false;

        }
        
    }

}
