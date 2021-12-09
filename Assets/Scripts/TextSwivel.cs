using UnityEngine;

public class TextSwivel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }
}
