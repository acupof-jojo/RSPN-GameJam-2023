using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAOE : MonoBehaviour
{
    public float maxSpeed = 3.0f;
    Rigidbody2D r2d;
    private Transform target;
    public float bulletDamage = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform _target) {
        target = _target;
    }

/*
    void FixedUpdate() {
        if(target == null) {
            Destroy(gameObject);
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;
        r2d.velocity = direction * maxSpeed;
    }
*/

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {

            //damage
            DamageOther(other);
            //destroy self
            Destroy(gameObject);

        }
    }

    void DamageOther(Collider2D other) {
        if(other.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent(typeof(Enemy)) as Enemy;
            enemy.health = enemy.health - bulletDamage;
            //Debug.Log(enemy.health);
        }
    }

}
