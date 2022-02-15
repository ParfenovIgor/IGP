using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    
    void Start() {
        for (int i = 0; i < 100; i++) {
            var position = new Vector3(0, 0, i);
            Instantiate(CoinPrefab, position, Quaternion.identity);
        }
    }
}
