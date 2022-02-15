using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        var playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;
        
        Debug.Log("You win. Your score is " + PlayerMovement.Score.ToString());
        playerMovement.enabled = false;

        var rigidbody = other.GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }
}
