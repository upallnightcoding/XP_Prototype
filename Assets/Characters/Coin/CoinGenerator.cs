using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private int density;
    [SerializeField] private int coinArea;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(1, density) == 1)
        {
            Vector3 pos = Random.insideUnitCircle * coinArea;
            Instantiate(coin, new Vector3(pos.x, 0.3f, pos.y), Quaternion.identity);
            coin.name = $"Coin: {count++}";
        }
    }
}
