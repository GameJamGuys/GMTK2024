using UnityEngine;

[CreateAssetMenu(fileName = "ResourceSO", menuName = "Scriptable Objects/ResourceSO")]
public class ResourceSO : ScriptableObject
{
    [SerializeField] private ResourceType _type;
    [SerializeField] private Sprite _sprite;

    public Sprite Image => _sprite;
    public ResourceType Type => _type;
}

public enum ResourceType
{
    Attack,
    Support,
    Build,
    Heal,
    Note
}