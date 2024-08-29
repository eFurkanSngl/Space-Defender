using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemies : MonoBehaviour
{
    [SerializeField] private GameObject _spawnEnemies;
    public float spawnInterval = 0.09f;
    private int _scoreValue = 10;  // her düşman değeri.
    

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Ground")
    //     {
    //         SpawnEnemies();
    //         Destroy(gameObject);
    //         Debug.Log("worked");
    //     }
    // }

    
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * spawnInterval * Time.deltaTime);


        if (transform.position.y < -4)
        {   
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            PlayerScore.Instance.IncreaseScore(_scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
