using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemies : MonoBehaviour
{
    
    public float spawnInterval = 0.09f;
    private int _enemiesValue = 10;  // her düşman değeri.
    private int _enemiesDamage = 20;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * spawnInterval * Time.deltaTime);


        // if (transform.position.y < -4)
        // {   
        //     Destroy(gameObject);
        // }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            PlayerScore.Instance.IncreaseScore(_enemiesValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            PlayerScore.Instance.IncreaseLive(_enemiesDamage);
            Destroy(gameObject);
            Player.Instance.isGameOver();
        }
    }

   
}
