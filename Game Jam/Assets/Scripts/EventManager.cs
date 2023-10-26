using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EventManager : MonoBehaviour
{

    public int money;
    public TextMeshProUGUI displayMoney;

    public static EventManager main;

    private void Awake() {
        main = this;
    }

    
    //public TextMechProUGUI moneyDisplay;

    // Start is called before the first frame update
    void Start()
    {
        money = 100;
        //displayMoney = FindObjectOfType<TextMeshProUGUI>();
        displayMoney.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount) {
        //moneyDisplay.text = money.ToString();
        money += amount;
        displayMoney.text = money.ToString();
    }
    
    public void spendMoney(int cost) {
        money -= cost;
        displayMoney.text = money.ToString();
    }

    public void gainMoney(int sellPrice) {
        money += sellPrice;
        displayMoney.text = money.ToString();
    }
}
