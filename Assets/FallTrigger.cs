using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
     public void OnTriggerEnter(Collider other) {
        var playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;
        
        Debug.Log("Fail");
        playerMovement.enabled = false;
    }
}
