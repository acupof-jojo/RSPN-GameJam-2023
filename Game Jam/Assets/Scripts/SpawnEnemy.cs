using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float spawnSpeed = 1.5f;
    float spawnWait = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(spawnWait > 0) {
            spawnWait -= Time.deltaTime;
        }
        else if (spawnWait <= 0) {
            GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation, this.transform);
            spawnWait += spawnSpeed;
        }
    }

}
