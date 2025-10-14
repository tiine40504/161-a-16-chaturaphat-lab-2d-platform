using UnityEngine;

public class Character : MonoBehaviour
{

    private int health;
    public int Health { get => health; set => health = (value < 0)? 0 : value; }

    protected Animation anim;
    protected Rigidbody2D rb;

    public void TakeDanage(int damage)
    {
        Health -= damage;
        Debug.Log($"{ this.name} took damage {damage}. Current Health {Health}");
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
