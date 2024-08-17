using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Resource : MonoBehaviour
{
    private readonly float _offsetY = 1.5f;

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

    public IEnumerator MoveTo(Harvester harvester)
    {
        while (enabled)
        {
            Vector3 finalTarget = new Vector3(harvester.transform.position.x, harvester.transform.position.y + _offsetY,
                harvester.transform.position.z);
            Vector3 direction = (finalTarget - transform.position).normalized;
            _rigidbody.AddForce(direction * harvester.MoveForce);
            yield return null;
        }
    }
}