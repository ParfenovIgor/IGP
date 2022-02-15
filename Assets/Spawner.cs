using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PlatformPrefab;
    public GameObject FinishPrefab;
    public GameObject CoinPrefab;
    float jump_length = 4.5f; // Approximate jump length given speed, jump speed, and gravitational constant derived from expiration.

    void Start() {
        int platform_number = Random.Range(10, 31);
        float pos_x = 0.0f;
        float pos_z = 0.0f;
        float direction = 0.0f; // Alternating 0.0f and 90.0f

        for (int i = 0; i < platform_number; i++) {
            float length;
            if (i == 0)
                length = 12.0f; // First platform is long to prepare for game
            else
                length = Random.Range(2.0f, 6.0f);
            var position = new Vector3( // The origin of block is center of it, hence add the half of size of block
                pos_x + length / 2.0f * Mathf.Sin(direction * Mathf.Deg2Rad), 
                0.0f, 
                pos_z + length / 2.0f * Mathf.Cos(direction * Mathf.Deg2Rad));
            var angle = new Vector3 (0.0f, direction, 0.0f);
            var rotation = Quaternion.Euler(angle);
            var scale = new Vector3 (1.0f, 1.0f, length + 1.0f);
            GameObject block = Instantiate(PlatformPrefab, position, rotation);
            block.transform.localScale = scale;

            if (Random.Range(0, 3) == 0) {
                int number_of_coins = Random.Range(1, 6);
                for (int j = 1; j <= number_of_coins; j++) { // Put coins on platform uniformly
                    var coin_position = new Vector3(
                        pos_x + length * j / (number_of_coins + 1) * Mathf.Sin(direction * Mathf.Deg2Rad), 
                        0.0f, 
                        pos_z + length * j / (number_of_coins + 1) * Mathf.Cos(direction * Mathf.Deg2Rad));
                    var coin_rotation = Quaternion.identity;
                    Instantiate(CoinPrefab, coin_position, coin_rotation);
                }
            }

            pos_x += length * Mathf.Sin(direction * Mathf.Deg2Rad);
            pos_z += length * Mathf.Cos(direction * Mathf.Deg2Rad);

            if (i + 1 != platform_number) { // No obstacles near finish
                if (Random.Range(0, 3) == 0) { // Put gap for jump
                    pos_x += jump_length * Mathf.Sin(direction * Mathf.Deg2Rad);
                    pos_z += jump_length * Mathf.Cos(direction * Mathf.Deg2Rad);
                }
                else { // Put next block
                    direction = 90.0f - direction;
                }
            }
        }

        { // Put finish
            float length = 1.0f;
            var position = new Vector3( // The origin of block is center of it, hence add the half of size of block
                pos_x + (length + 1.0f) / 2.0f * Mathf.Sin(direction * Mathf.Deg2Rad), 
                0.0f, 
                pos_z + (length + 1.0f) / 2.0f * Mathf.Cos(direction * Mathf.Deg2Rad));
            var angle = new Vector3 (0.0f, direction, 0.0f);
            var rotation = Quaternion.Euler(angle);
            var scale = new Vector3 (1.0f, 1.0f, length);
            GameObject finish = Instantiate(FinishPrefab, position, rotation);
            finish.transform.localScale = scale;
        }
    }
}
