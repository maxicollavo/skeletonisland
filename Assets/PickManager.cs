using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickManager : MonoBehaviour
{
    public int PicksRequeridos;
    public int Picks;
    public int ConsumablesLayer;
    public int PickeablesLayer;
    public int PlusTimeLayer;
    public int BulletPick;
    public GameSceneManager gameSceneManager;
    LifeController lifeController;
    public TimeController timeController;
    PlayerInputManager playerInputManager;
    [SerializeField] private AudioSource coinPickEffect;
    [SerializeField] private AudioSource bulletPickEffect;
    [SerializeField] private AudioSource aidPickEffect;
    [SerializeField] private AudioSource timePickEffect;



    // Start is called before the first frame update
    void Start()
    {
        PicksRequeridos = Config.PickRequeridos;
        Picks = Config.Picks;
        ConsumablesLayer = Config.ConsumablesLayer;
        PickeablesLayer = Config.PickeablesLayer;
        PlusTimeLayer = Config.PlusTimeLayer;
        BulletPick = Config.BulletPick;
        lifeController = GetComponent<LifeController>();
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == PickeablesLayer)
        {
            collision.gameObject.SetActive(false);
            Picks++;
            coinPickEffect.Play();
        }
        if (collision.gameObject.layer == ConsumablesLayer)
        {
            collision.gameObject.SetActive(false);
            lifeController.IncrementLives(Config.IncrementLives);
            aidPickEffect.Play();
        }
        if (collision.gameObject.layer == PlusTimeLayer)
        {
            collision.gameObject.SetActive(false);
            timeController.IncrementTime(Config.IncrementTime);
            timePickEffect.Play();
        }
        if (collision.gameObject.layer == BulletPick)
        {
            collision.gameObject.SetActive(false);
            playerInputManager.IncrementBullets(Config.IncrementBullets);
            bulletPickEffect.Play();
        }
    }

}



