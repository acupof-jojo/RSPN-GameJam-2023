using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerUpgradeHandler : MonoBehaviour
{

    [SerializeField] private CircleCollider2D interactCollider;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button sellButton;

    void Start()
    {
        interactCollider = GetComponent<CircleCollider2D>();
        sellButton.onClick.AddListener(SellTower);
        upgradeButton.onClick.AddListener(UpgradeTower);
    }

        void OnMouseDown() {
        if(UImanager.main.IsHoveringUI()) {
            Debug.Log("hovering");
            return;
        }

        OpenUpgradeUI();
    }

    void SellTower() {
        SendMessageUpwards("SellTower");
    }

    void UpgradeTower() {
        SendMessageUpwards("UpgradeTower");
    }

    public void OpenUpgradeUI() {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI() {
        upgradeUI.SetActive(false);
        UImanager.main.SetHoveringState(false);
    }

    [SerializeField] private GameObject rangeVisual;

    void OnMouseEnter() {
        rangeVisual.SetActive(true);
    }

    void OnMouseExit() {
        rangeVisual.SetActive(false);
    }
}
