using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GnomeArtSetter : MonoBehaviour
{
    [SerializeField]
    List<SpriteCollection> outfits;

    //public void ChangeOutfit()

    private void Start()
    {
        foreach(SpriteCollection collection in outfits)
        {
            switch (collection.name)
            {
                case "body":
                    collection.rend.sprite = collection.bodyBuild[GnomeArtData.BODY];
                    break;
                case "beard":
                    collection.rend.sprite = collection.bodyBuild[GnomeArtData.BEARD];
                    break;
                case "hat":
                    collection.rend.sprite = collection.bodyBuild[GnomeArtData.HAT];
                    break;
                case "strings":
                    collection.rend.sprite = collection.bodyBuild[GnomeArtData.STRINGS];
                    break;
            }
                
        }
    }

}

[System.Serializable]
public class SpriteCollection
{
    public string name;
    public Sprite[] bodyBuild;
    public SpriteRenderer rend;
    public int fit;
}