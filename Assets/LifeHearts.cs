using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeHearts : MonoBehaviour
{
    Text textComponent;
    public LifeController LifeController;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "Vidas: " + LifeController.vidas;
    }
}
