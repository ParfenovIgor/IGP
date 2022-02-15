using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        var playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null)
            return;

        Destroy(gameObject);
        
        PlayerMovement.Score++;
        Debug.Log("Score: " + PlayerMovement.Score.ToString());
    }

    public void Update() {
        var position = transform.position;
        position.y = Mathf.Sin((float)Time.timeAsDouble * 5.0f) * 0.3f + 1.3f; // Use trigonometric function for floating
        transform.position = position;

        var rotation = transform.rotation.eulerAngles;
        rotation.y = (float)Time.timeAsDouble * 100.0f;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
