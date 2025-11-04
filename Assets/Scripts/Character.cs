using UnityEngine;
using System; 

public class Character : MonoBehaviour
{
    private int health;
    private int maxHealth; 

    
    
    // Action<int, int> หมายถึง event นี้จะส่งค่า 2 ตัว (int currentHealth, int maxHealth)
    public event Action<int, int> OnHealthChanged;
    

    public int Health
    {
        get => health;
        set
        {
            // ตรวจสอบว่าค่าใหม่ไม่ต่ำกว่า 0
            int newHealth = (value < 0) ? 0 : value;

            // เช็คว่าค่าพลังชีวิตเปลี่ยนไปจริงหรือไม่
            if (newHealth != health)
            {
                health = newHealth;

                
                // Invoke คือการเช็คว่ามีใครมา subscribe event นี้หรือไม่ ถ้ามีก็ค่อยเรียก
                OnHealthChanged?.Invoke(health, maxHealth);
                // ------------------------
            }
        }
    }

    // เพิ่ม Property ให้คลาสอื่นอ่านค่า maxHealth ได้
    public int MaxHealth { get => maxHealth; }

    protected Animator anim;
    protected Rigidbody2D rb;

    public void Intialize(int starthealth)
    {
        maxHealth = starthealth; // <-- เก็บค่าพลังชีวิตสูงสุด
        Health = starthealth; // Health จะไปเรียก set accessor และยิง event ครั้งแรก
        Debug.Log($"{this.name} initial Health: {this.Health}.");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // (ย้ายไปอยู่ใน set ของ Health แล้ว)
        // OnHealthChanged?.Invoke(health, maxHealth); // ยิง event ตอนเริ่มต้น
    }

    public void TakeDamage(int damage)
    {
        Health -= damage; // <-- การลดพลังชีวิตจะไปเรียก set accessor ด้านบน
        Debug.Log($"{this.name} took damage {damage}. Current Health {Health}");

        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
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