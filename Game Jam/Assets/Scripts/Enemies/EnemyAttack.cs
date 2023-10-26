using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    CircleCollider2D rangeCollider;

    public float attackSpeed = 0.3f;
    float attackWait = 0;
    public float enemyDamage = 3.0f;

    private int targetListSize;

    public List<Collider2D> targetList = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        rangeCollider = GetComponent<CircleCollider2D>();
        rangeCollider.radius = 1f;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Tower") {
            //add to a targeting list
            targetList.Add(other);
            targetListSize++;
            Debug.Log(targetList[0]);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Tower") {
            //remove from targeting list
            targetList.Remove(other);
            targetListSize--;

        }
    }

    void DamageOther(Collider2D other) {
        if(other.tag == "Tower") {
            TowerHP tower = other.gameObject.GetComponent(typeof(TowerHP)) as TowerHP;
            tower.health = tower.health - enemyDamage;
            Debug.Log("demage "+ tower.health);
        }
    }

    void OnTriggerStay2D(Collider2D other) {

        if (attackWait <= 0) {
            for(int i = 0 ; i < targetListSize ; i++) {
                DamageOther(targetList[i]);
            }
            attackWait += attackSpeed;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(attackWait > 0) {
            attackWait -= Time.deltaTime;
        }
    }
}