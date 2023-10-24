using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CircleCollider2D))]



public class AOE : MonoBehaviour
{

    //Tower tower1 = new Tower(2,0.5,5);
    CircleCollider2D rangeCollider;

    public float attackSpeed = 0.3f;
    float attackWait = 0;
    public float aoeDamage = 3.0f;

    public int sellPrice = 10;

    private int targetListSize;


    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private GameObject upgradeTo;
    [SerializeField] private GameObject buildPlot;

    public List<Collider2D> targetList = new List<Collider2D>();
    

    // Start is called before the first frame update
    void Start()
    {
        rangeCollider = GetComponent<CircleCollider2D>();
        sellButton.onClick.AddListener(SellTower);
        upgradeButton.onClick.AddListener(UpgradeTower);
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



    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            //add to a targeting list
            targetList.Add(other);
            targetListSize++;
            Debug.Log(targetList[0]);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Enemy") {
            //remove from targeting list
            targetList.Remove(other);
            targetListSize--;

        }
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

    void UpgradeTower() {
        if(EventManager.main.money < 15) {
            return;
        }
        
        EventManager.main.spendMoney(15);

        GameObject upgrade = Instantiate(upgradeTo, transform.position, transform.rotation);

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

    void DamageOther(Collider2D other) {
        if(other.tag == "Enemy") {
            Enemy enemy = other.gameObject.GetComponent(typeof(Enemy)) as Enemy;
            enemy.health = enemy.health - aoeDamage;
            Debug.Log("demage "+ enemy.health);
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

    void FixedUpdate() {
        if(attackWait > 0) {
            attackWait -= Time.deltaTime;
        }
    }


}
