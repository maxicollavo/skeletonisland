using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletCount : MonoBehaviour
{
    Text textComponent;
    public PlayerInputManager playerInputManager;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInputManager.balasRestantes <= Config.SinBalas)
        {
            textComponent.text = "Balas: " + Config.SinBalas;
        }
        textComponent.text = "Balas: " + PlayerInputManager.balasRestantes;
    }

}