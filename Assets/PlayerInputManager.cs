using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    Rigidbody2D _rb2d;
    Vector2 _dir = new Vector2(1,0);
    Vector2 _movement;
    Animator anim;
    Vector2 initialPosition;
    public float speed = 150;
    public float force = 20;
    public GameObject bulletPrefab;
    public float dashDuration = 0.1f;
    public static int balasRestantes = Config.BalasRestantes;
    [SerializeField] private AudioSource playerShootEffect;


    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            anim.SetBool("isWalking", true);
            _dir.x = x;
            _dir.y = y;
        }
        else
            anim.SetBool("isWalking", false);
        _movement.x = x;
        _movement.y = y;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }


        anim.SetFloat("Horizontal", x);
        anim.SetFloat("Vertical", y);

    }

    void FixedUpdate()
    {
        Move();
    }

    void Shoot()
    {
        playerShootEffect.Play();
        balasRestantes--;
        if (balasRestantes <= 0)
        {
            return;
        }
        var bulletGo = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGo.GetComponent<Bullet>().dir = _dir;
    }

    public void IncrementBullets(int extraBullets)
    {
        balasRestantes += extraBullets;
    }

    void Move()
    {
        _rb2d.velocity = _movement * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var lifeController = GetComponent<LifeController>();

        if (collision.gameObject.layer == 6)
        {
            lifeController.Hit();
        }

    }
}
