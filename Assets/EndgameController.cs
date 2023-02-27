using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameController : MonoBehaviour
{
    public PickManager pickManager;
    public GameObject endgameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickManager.Picks >= pickManager.PicksRequeridos)
        {
            endgameText.SetActive(true);
        }
    }
}
