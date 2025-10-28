using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public IShootable Shooter;

    public abstract void Move();

    public abstract void OnHitWith(Character character);


    public void InitWeapon(int newDamage, IShootable newShooter)
    {
        damage = newDamage;
        Shooter = newShooter;
    }

    public int GetShootDirectione()
    {
        float vale = Shooter.ShootPoint.position.x - Shooter.ShootPoint.parent.position.x;

        if (vale < 0)
            return 1;
        else return -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            OnHitWith(character);
            
            Destroy(this.gameObject,5f);
        }
    }




    void Start()
    {
        
    }





}
