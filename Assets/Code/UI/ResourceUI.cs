using UnityEngine;
using TMPro;
using DG.Tweening;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] Resource.Types type;

    [SerializeField] Transform icon;
    [SerializeField] TMP_Text count;

    private void OnEnable()
    {
        CheckResource(type);
        WalletData.OnChangeWallet += CheckResource;
    }

    private void OnDisable()
    {
        WalletData.OnChangeWallet -= CheckResource;
    }

    void CheckResource(Resource.Types changeType)
    {
        if(changeType == type)
        {
            icon.DOScale(new Vector3(1.2f, 1.2f, 1.2f), .1f);
            print(WalletData.GetResourceCount(type).ToString());
            count.text = WalletData.GetResourceCount(type).ToString();
            icon.DOScale(new Vector3(1f, 1f, 1f), .1f);
        }
    }
}
