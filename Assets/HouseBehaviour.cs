using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
    public PickManager pickManager;
    public LayerMask mask;
    public float rango = 4f;
    public GameSceneManager gameSceneManager;
    [SerializeField] private AudioSource escapeEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickManager.Picks >= pickManager.PicksRequeridos)
        {
            escapeEffect.Play();
            if (Physics2D.OverlapCircle(transform.position, rango, mask))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                   gameSceneManager.LoadWinMenu();
                }
            }
        }
    }
}
