using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buildable : MonoBehaviour
{

    public GameObject basicTower;
    public GameObject LRTower;
    public GameObject AOETower;
    bool menuOpen = false;

    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button basicButton;
    [SerializeField] private Button LRButton;
    [SerializeField] private Button AOEButton;


    public int BasicCost = 10;
    public int LRCost = 10;
    public int AOECost = 12;

    // Start is called before the first frame update
    void Start()
    {
        basicButton.onClick.AddListener(BuildBasicTower);
        LRButton.onClick.AddListener(BuildLRTower);
        AOEButton.onClick.AddListener(BuildAOETower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseDown() {

        if(UImanager.main.IsHoveringUI()) {
            Debug.Log("hovering");
            return;
        }

        OpenUpgradeUI();
        Debug.Log(EventManager.main.money);
    }


    public void OpenUpgradeUI() {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI() {
        upgradeUI.SetActive(false);
        UImanager.main.SetHoveringState(false);
    }


    public void BuildBasicTower() {
        if(EventManager.main.money < BasicCost) {
            return;
        }
        
        EventManager.main.spendMoney(BasicCost);

        GameObject building = Instantiate(basicTower, transform.position, transform.rotation);

        Destroy(gameObject);
        
        CloseUpgradeUI();

    }

    public void BuildLRTower() {
        if(EventManager.main.money < LRCost) {
            return;
        }
        
        EventManager.main.spendMoney(LRCost);

        GameObject building = Instantiate(LRTower, transform.position, transform.rotation);

        Destroy(gameObject);
        
        CloseUpgradeUI();

    }

    public void BuildAOETower() {
        if(EventManager.main.money < AOECost) {
            return;
        }
        
        EventManager.main.spendMoney(AOECost);

        GameObject building = Instantiate(AOETower, transform.position, transform.rotation);

        Destroy(gameObject);
        
        CloseUpgradeUI();

    }



}
