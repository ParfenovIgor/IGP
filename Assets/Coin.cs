using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        var playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;

        Debug.Log("Coin was collected!");
        Destroy(gameObject);
    }
}
