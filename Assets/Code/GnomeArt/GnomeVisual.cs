using UnityEngine;
using System.Collections.Generic;

public class GnomeVisual : MonoBehaviour
{
    [SerializeField] Gamer gamer;
    [SerializeField] GameObject front, back, build;

    Animator anim;

    public enum VisualType { Front, Back, Build};
    private VisualType lastType;

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

        if (lastType != VisualType.Build && gamer.IsWalking())
        {
            if (gamer.InputVector.y > 0) SetType(VisualType.Back);
            if (gamer.InputVector.y < 0) SetType(VisualType.Front);
        }

        if (Input.GetKeyDown(KeyCode.B)) StartBuild();
    }

    private void StartBuild()
    {
        SetType(VisualType.Build);
        anim.SetTrigger("Build");
    }

    public void SetType(VisualType type)
    {
        if (type == lastType) return;

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
        lastType = type;
    }
}
