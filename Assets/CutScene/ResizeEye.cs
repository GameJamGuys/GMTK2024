using System.Collections;
using TMPro;
using UnityEngine;

public class ResizeEye : MonoBehaviour
{
    [SerializeField] private float _speedSize = .02f;
    [SerializeField] private float _speedPosition = 10f;

    //IEnumerator Start()
    //{
    //   transform.Translate(Vector3.up * Time.deltaTime * _speed);
    //   yield return true;

    //}

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.y < .4f)
            return;

        transform.localScale = transform.localScale - new Vector3(0, Time.deltaTime * _speedSize, 0);
        transform.Translate(Vector3.up * Time.deltaTime * _speedPosition);
    }
}
