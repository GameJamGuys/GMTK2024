using UnityEngine;

public class ResizeDwarf : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale + new Vector3(Time.deltaTime * 0.05f, Time.deltaTime * 0.05f, Time.deltaTime * 0.05f);

    }
}
