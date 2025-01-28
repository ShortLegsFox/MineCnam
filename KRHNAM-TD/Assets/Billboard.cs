using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform Cam;
    void LateUpdate()
    {
        transform.LookAt(transform.position + Cam.forward);
    }
}
