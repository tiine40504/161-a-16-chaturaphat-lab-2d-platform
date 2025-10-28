using UnityEngine;

public class Player : Character , IShootable
{
    [field : SerializeField]public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float waitTime { get; set; }





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(100);
        ReloadTime = 1.0f;
        waitTime = 0.0f;
    }

    public void OnHitWith(Enemy enemy)
    {
       TakeDamage(enemy.DamageHit);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        
        if (enemy != null) {
            OnHitWith(enemy);
            Debug.Log($"{this.name} Hit with {enemy.name}");
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void FixedUpdate()
    {
        waitTime += Time.fixedDeltaTime;
    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && waitTime >= ReloadTime) 
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null) 
            
                
                banana.InitWeapon(20,this);

            waitTime = 0.0f;

            
        }
    }


}
