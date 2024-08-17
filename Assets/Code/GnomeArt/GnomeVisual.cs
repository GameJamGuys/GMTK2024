using UnityEngine;
using System.Collections.Generic;

public class GnomeVisual : MonoBehaviour
{
    [SerializeField] GameObject front, back, build;

    public enum VisualType { Front, Back, Build};

    private void DeactiveAll()
    {
        front.SetActive(false);
        back.SetActive(false);
        build.SetActive(false);
    }

    public void SetType(VisualType type)
    {
        DeactiveAll();
        switch (type)
        {
            case VisualType.Front:
                front.SetActive(true);
                break;
            case VisualType.Back:
                back.SetActive(true);
                break;
            case VisualType.Build:
                build.SetActive(true);
                break;
        }
    }
}
