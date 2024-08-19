using System;
using UnityEngine;
using TowerSystem;
using UnityEngine.UI;

public class TowerBuyButton : MonoBehaviour
{
    [SerializeField] TowerType type;

    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(BuyTower);
        UpdateInteract();
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(BuyTower);
    }

    void BuyTower()
    {
        TowerShop.Instance.BuildTower(type);
        UpdateInteract();
    }

    private void UpdateInteract()
    {
        button.interactable = TowerShop.Instance.CheckTowerCost(type);
    }
}
