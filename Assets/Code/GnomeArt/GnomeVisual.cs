using UnityEngine;
using System.Collections.Generic;

public class GnomeVisual : MonoBehaviour
{
    [SerializeField] Gamer gamer;
    [SerializeField] GameObject front, back, build;

    Animator anim;

    public enum VisualType { Front, Back, Build};

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void DeactiveAll()
    {
        front.SetActive(false);
        back.SetActive(false);
        build.SetActive(false);
    }

    private void Update()
    {
        anim.SetBool("isWalk", gamer.IsWalking());
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
