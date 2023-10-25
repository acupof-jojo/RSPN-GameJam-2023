using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHP : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D r2d;
    public GameObject Buildable;

    [Header("References")]
    [SerializeField] public float health = 10;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
       
        if(health <= 0) {
            DestroyTower();
            
        }

    }
    public void DestroyTower() {
        GameObject building = Instantiate(Buildable, transform.position, transform.rotation);
        Destroy(gameObject);

    }
    
}
