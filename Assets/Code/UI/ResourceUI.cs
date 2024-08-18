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
    }

    void CheckResource(Resource.Types changeType)
    {
        if(changeType == type)
        {
            icon.DOShakeScale(0.2f, 1.5f, 5, 30);
            count.text = WalletData.GetResourceCount(type).ToString();
            icon.DOScale(new Vector3(1f, 1f, 1f), .1f);
        }

    }
}
