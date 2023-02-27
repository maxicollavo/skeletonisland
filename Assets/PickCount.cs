using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickCount : MonoBehaviour
{
    Text textComponent;
    public PickManager PickManager;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "Monedas: " + PickManager.Picks;
    }
}