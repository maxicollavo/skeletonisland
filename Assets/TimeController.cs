using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeController : MonoBehaviour
{
    public GameSceneManager gameSceneManager;
    public float tiempoRestante;

    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = Config.TiempoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0)
        {
            gameSceneManager.LoadMainMenu();
        }
    }

    public void IncrementTime(int extraTime)
    {
        tiempoRestante += extraTime;
    }
}
