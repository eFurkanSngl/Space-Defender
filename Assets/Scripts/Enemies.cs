using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemies : MonoBehaviour
{
    [SerializeField] private GameObject _spawnEnemies;
    public float fallSpeed = 2f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            SpawnEnemies();
            Destroy(gameObject);
            Debug.Log("worked");
        }
    }

    public void SpawnEnemies()
    {
        Vector2 pos = new Vector2(Random.Range(-7, 7), y: 4.15f);
        Instantiate(_spawnEnemies,pos,Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }
  
}
