using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject player;
    public LayerMask mask;
    public float rango = 4f;
    public int lifeTime = 2;
    public GameObject bulletPrefab;
    GameObject bulletGo;
    float bulletLifeTime;
    [SerializeField] private AudioSource enemyShootEffect;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, rango, mask))
        {
            if (bulletGo) bulletLifeTime += Time.deltaTime;

            if (bulletGo == null || bulletLifeTime >= lifeTime)
            {
                Shoot();
                bulletLifeTime = 0;
            }
        }
    }

    private void Shoot()
    {
        Vector3 direction = EvaluateDirection();
        bulletGo = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bulletGo.GetComponent<Bullet>().dir = direction;
        enemyShootEffect.Play();
    }

    private Vector3 EvaluateDirection()
    {
        float x = 0, y = 0;

        if (player.transform.position.x > transform.position.x + 1)
            x = 1;
        else if (player.transform.position.x < transform.position.x - 1)
            x = -1;

        if (player.transform.position.y > transform.position.y + 1)
            y = 1;
        else if (player.transform.position.y < transform.position.y - 1)
            y = -1;

        return new Vector3(x, y, 0);
    }
}
