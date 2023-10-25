using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{

    // public float maxSpeed = 2.0f;
    Rigidbody2D r2d;
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
            EventManager.main.AddMoney(award);
            Destroy(gameObject);
        }

    }



}
