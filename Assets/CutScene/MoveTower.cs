using System.Collections;
using TMPro;
using UnityEngine;

public class MoveTower : MonoBehaviour
{
    [SerializeField] private float _speed = 90f;

    //IEnumerator Start()
    //{
    //   transform.Translate(Vector3.up * Time.deltaTime * _speed);
    //   yield return true;

    //}

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
    }
}
