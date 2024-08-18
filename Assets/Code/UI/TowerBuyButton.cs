using UnityEngine;
using TowerSystem;
using UnityEngine.UI;

public class TowerBuyButton : MonoBehaviour
{
    [SerializeField] TowerType type;

    Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();

        button.interactable = TowerShop.Instance.CheckTowerCost(type);
        button.onClick.AddListener(BuyTower);
    }

    void BuyTower()
    {
        TowerShop.Instance.BuildTower(type);
    }

    
}
