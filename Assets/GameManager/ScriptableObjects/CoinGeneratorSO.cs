using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinGeneratorSO", menuName = "ScriptableObjects/Coin Generator")]
public class CoinGeneratorSO : ScriptableObject
{
    public int frequency;
    public int coinCreationArea;
    public GameObject coin;
}
