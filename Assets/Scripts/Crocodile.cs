using UnityEngine;

public class crocodile : Enemy , IShootable
{

    [SerializeField]private float atkRange;
    public Player player;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float waitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(50);
        DamageHit = 30;

        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();

        ReloadTime = 1.0f;
    }

    private void FixedUpdate()
    {
        waitTime += Time.fixedDeltaTime;
        Behavior();
    }

    public override void Behavior()
    {
        Vector2 distance = transform.position - player.transform.position;

        if (distance.magnitude <= atkRange) 
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }


    }

    public void Shoot()
    {
        if (Bullet != null) 
        {
            if (waitTime >= ReloadTime)

            {
                anim.SetTrigger("Shoot");
                var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
                Rock rock = bullet.GetComponent<Rock>();
                if (rock != null)




                    rock.InitWeapon(20, this);

                waitTime = 0.0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
