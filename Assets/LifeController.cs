using System;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public GameSceneManager gameSceneManager;
    [HideInInspector] public int vidas;
    public int vidasMaximas;

    public void Start()
    {
        vidas = vidasMaximas;
    }

    public void Hit()
    {
        
        vidas--;
        if (vidas <= 0)
        {
            gameObject.SetActive(false);
            if (gameSceneManager != null)
            {
                gameSceneManager.LoadDeadMenu();
            }

        }
    }

    public void IncrementLives(int extraLives)
    {
        if (vidas == vidasMaximas)
        {
            return;
        }
        vidas += extraLives;
    }
}
