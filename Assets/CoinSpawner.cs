using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Pick;
    public int cantidad;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 posicion = new Vector3(
                Random.Range(-38.87f, 28.83f),
                Random.Range(-18.88f, 19.07f),
                0);
            Instantiate(Pick, posicion, Quaternion.identity);
        }
    }
}
