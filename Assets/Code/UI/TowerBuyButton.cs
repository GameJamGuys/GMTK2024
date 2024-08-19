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
        button.onClick.AddListener(BuyTower);
    }

    private void OnBecameVisible()
    {
        button.interactable = TowerShop.Instance.CheckTowerCost(type);
    }

    void BuyTower()
    {
        TowerShop.Instance.BuildTower(type);
    }

    
}
