using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceSO _data;
    
    private SpriteRenderer _spriteRenderer;
    private Rigidbody _rigidbody;

    public ResourceSO Data => _data;

    private void OnEnable()
    {
        if (_data == null)
        {
            throw new ArgumentNullException(nameof(_data));
        }

        _rigidbody = GetComponent<Rigidbody>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _data.Image;
    }

    public IEnumerator MoveTo(Transform target)
    {
        while (enabled)
        {
            _rigidbody.MovePosition(target.position);
            yield return null;
        }
    }
    
    
}