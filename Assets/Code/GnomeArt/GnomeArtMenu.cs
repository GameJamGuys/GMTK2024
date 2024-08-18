using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GnomeArtMenu : MonoBehaviour
{
    public enum OutfitType { Body, Hat, Beard, Strigs};

    [SerializeField]
    ImageCollection bodyoutfit;
    [SerializeField]
    ImageCollection hatoutfit;
    [SerializeField]
    ImageCollection beardoutfit;
    [SerializeField]
    ImageCollection stringoutfit;

    [Space]
    [SerializeField] PauseMenu pause;

    private void Start()
    {
        pause.TogglePauseGame();

        bodyoutfit.image.sprite = bodyoutfit.bodyBuild[GnomeArtData.BODY];
        hatoutfit.image.sprite = hatoutfit.bodyBuild[GnomeArtData.HAT];
        beardoutfit.image.sprite = beardoutfit.bodyBuild[GnomeArtData.BEARD];
        stringoutfit.image.sprite = stringoutfit.bodyBuild[GnomeArtData.STRINGS];
    }

    public void UpBody() => SetFit(bodyoutfit, 1, OutfitType.Body);
    public void DownBody() => SetFit(bodyoutfit, -1, OutfitType.Body);

    public void UpHat() => SetFit(hatoutfit, 1, OutfitType.Hat);
    public void DownHat() => SetFit(hatoutfit, -1, OutfitType.Hat);

    public void UpBeard() => SetFit(beardoutfit, 1, OutfitType.Beard);
    public void DownBeard() => SetFit(beardoutfit, -1, OutfitType.Beard);

    public void UpString() => SetFit(stringoutfit, 1, OutfitType.Strigs);
    public void DownString() => SetFit(stringoutfit, -1, OutfitType.Strigs);

    public void SetFit(ImageCollection work, int step, OutfitType type)
    {
        work.fit += step;
        if (work.fit >= work.bodyBuild.Length)
        {
            work.fit = 0;
        }

        work.image.sprite = work.bodyBuild[work.fit];

        switch (type)
        {
            case OutfitType.Body:
                GnomeArtData.BODY = work.fit;
                break;
            case OutfitType.Hat:
                GnomeArtData.HAT = work.fit;
                break;
            case OutfitType.Beard:
                GnomeArtData.BEARD = work.fit;
                break;
            case OutfitType.Strigs:
                GnomeArtData.STRINGS = work.fit;
                break;
        }
    }

    public void ClosePanel()
    {
        pause.SetResume();
        gameObject.SetActive(false);
    }

}

[System.Serializable]
public class ImageCollection
{
    public Sprite[] bodyBuild;
    public Image image;
    public int fit = 0;
}
