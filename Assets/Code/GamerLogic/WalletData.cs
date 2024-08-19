using UnityEngine;
using System;

public static class WalletData
{
    public static int attackResource;
    public static int buildResource;
    public static int supportResource;

    public static int notesCount;

    public static event Action<Resource.Types> OnChangeWallet;

    public static void AddResource(Resource.Types type, int amount = 1) => ChangeResource(type, amount);
    public static void RemoveResource(Resource.Types type, int amount = 1) => ChangeResource(type, -amount);

    public static void ChangeResource(Resource.Types type, int amount = 1)
    {
        switch (type)
        {
            case Resource.Types.Attack:
                attackResource += amount;
                break;
            case Resource.Types.Build:
                buildResource += amount;
                break;
            case Resource.Types.Support:
                supportResource += amount;
                break;
        }

        OnChangeWallet?.Invoke(type);
    }

    public static int GetResourceCount(Resource.Types type)
    {
        switch (type)
        {
            case Resource.Types.Attack:
                return attackResource;
            case Resource.Types.Build:
                return buildResource;
            case Resource.Types.Support:
                return supportResource;
        }
        return 0;
    }

    public static void SetAllData(int amount)
    {
        attackResource = amount;
        buildResource = amount;
        supportResource = amount;
        OnChangeWallet?.Invoke(Resource.Types.Attack);
        OnChangeWallet?.Invoke(Resource.Types.Build);
        OnChangeWallet?.Invoke(Resource.Types.Support);
    }

    public static void ResetData() => SetAllData(0);
}
