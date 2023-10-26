using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    // public float maxSpeed = 2.0f;
    Rigidbody2D r2d;
    [Header("Attributes")]
    public float health = 10;
    public int award = 1;


    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        // r2d.velocity = new Vector2((1) * maxSpeed, r2d.velocity.y);

        if(health <= 0) {
            Debug.Log("AHHHH");
            EnemySpawner.enemiesAlive--;
            Debug.Log(EnemySpawner.enemiesAlive);
            Debug.Log(EnemySpawner.enemiesLeftToSpawn);
            EventManager.main.AddMoney(award);
            Destroy(gameObject);
            if(EnemySpawner.enemiesAlive == 0 && EnemySpawner.enemiesLeftToSpawn == 0){
                EventManager.main.AddMoney(EnemySpawner.waveAwards[EnemySpawner.currentWave-1]);
                Debug.Log("Wave award "+EnemySpawner.waveAwards[EnemySpawner.currentWave-1] );
                EnemySpawner.currentWave++;
            }
        }

    }



}
