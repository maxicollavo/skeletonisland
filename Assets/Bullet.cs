using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    [HideInInspector] public Vector3 dir;
    float lifetime;
    public int targetLayer;
    public GameObject aidkit;
    public GameObject pick;
    public GameObject clock;
    public Config config;
    int ProbDrop;
    int ProbPick;
    int ProbAidMed;
    int ProbClock;
    int EnemiesLayer;


    // Start is called before the first frame update
    void Start()
    {
        ProbPick = Config.ProbPick;
        ProbAidMed = Config.ProbAidMed;
        ProbClock = Config.ProbClock;
        EnemiesLayer = Config.EnemiesLayer;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= Config.BulletLifetime)
        {
            gameObject.SetActive(false);
        }
        transform.position += dir * speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == targetLayer)
        {
            collision.gameObject.GetComponent<LifeController>().Hit();
            gameObject.SetActive(false);
            ProbDrop = Random.Range(0,9);
            if (collision.gameObject.layer == EnemiesLayer)
            {
                if (ProbDrop == ProbPick)
                {
                    Instantiate(pick, transform.position, transform.rotation);
                }
                if (ProbDrop == ProbAidMed)
                {
                    Instantiate(aidkit, transform.position, transform.rotation);
                }
                if (ProbDrop == ProbClock)
                {
                    Instantiate(clock, transform.position, transform.rotation);
                }
            }
        }
    }
}
