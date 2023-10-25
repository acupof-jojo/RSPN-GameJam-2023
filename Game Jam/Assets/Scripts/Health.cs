using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private int hitPoints = 2;

    private bool isDestroyed = false;
    // Start is called before the first frame update

    private void takeDamage(int dmg)
    {
        hitPoints -= dmg;

        if(hitPoints <= 0 && isDestroyed){
            EnemySpawner.onEnemyDestroy.Invoke();
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
