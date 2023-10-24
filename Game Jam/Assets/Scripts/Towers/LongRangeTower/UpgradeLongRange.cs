using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CircleCollider2D))]



public class UpgradeLongRange : MonoBehaviour
{

    //Tower tower1 = new Tower(2,0.5,5);
    CircleCollider2D rangeCollider;
    public GameObject prefabProjectile;

    public float attackSpeed = 1.0f;
    float attackWait = 0;


    public int sellPrice = 20;


    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private GameObject buildPlot;

    public List<Collider2D> targetList = new List<Collider2D>();
    

    // Start is called before the first frame update
    void Start()
    {
        rangeCollider = GetComponent<CircleCollider2D>();
        sellButton.onClick.AddListener(SellTower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // LEGACY TARGETING CODE
/*
    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Enemy") {
            if(attackWait > 0) {
                attackWait -= Time.deltaTime;
            }
            else if (attackWait <= 0) {
                attack(other);
                attackWait += attackSpeed;
            }
            
        }
    }
*/

    void FixedUpdate() {
        if(attackWait > 0) {
                attackWait -= Time.deltaTime;
        }
        else if (attackWait <= 0 && targetList.Count > 0) {
            if (targetList.Count > 0) {
                attack(targetList[0]);
            }
            attackWait += attackSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            //add to a targeting list
            targetList.Add(other);
            Debug.Log(targetList[0]);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Enemy") {
            //remove from targeting list
            targetList.Remove(other);

        }
    }

    void attack(Collider2D other) {
        GameObject projObj = Instantiate(prefabProjectile, transform.position, transform.rotation, this.transform);
        Projectile projScript = projObj.GetComponent<Projectile>();
        Transform attackTarget = other.transform;
        projScript.SetTarget(attackTarget);
    }

    void OnMouseDown() {
        if(UImanager.main.IsHoveringUI()) {
            Debug.Log("hovering");
            return;
        }

        OpenUpgradeUI();
    }

    void SellTower() {
        EventManager.main.gainMoney(sellPrice);

        GameObject buildable = Instantiate(buildPlot, transform.position, transform.rotation);

        CloseUpgradeUI();
        Destroy(gameObject);
    }


    public void OpenUpgradeUI() {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI() {
        upgradeUI.SetActive(false);
        UImanager.main.SetHoveringState(false);
    }


}
