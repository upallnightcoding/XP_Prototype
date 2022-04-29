using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] CoinGeneratorSO gameState;
    [SerializeField] private GameObject coin;
    [SerializeField] private int frequency;
    [SerializeField] private int coinCreationArea;

    void FixedUpdate()
    {
        if (Random.Range(1, gameState.frequency) == 1)
        {
            Vector3 pos = Random.insideUnitCircle * coinCreationArea;
            Instantiate(coin, new Vector3(pos.x, 0.3f, pos.y), coin.transform.rotation);
        }
    }
}
