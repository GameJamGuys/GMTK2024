using DG.Tweening;
using System;
using UnityEngine;

[Serializable]
public class ScaleSettings
{
    [SerializeField] private float _duration = 0.25f;
    [SerializeField] private Vector3 _strength = new Vector3(1f, 1f, 1f);
    [SerializeField] private Ease _ease = Ease.InBounce;

    public float Duration => _duration;
    public Vector3 Strength => _strength;
    public Ease Ease => _ease;
}