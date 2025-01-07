using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public float speed = 10f;
    public float edgeThreshold = 10f;
    public int minDistance = 3;
    public int maxDistance = 20;


    void Update()
    {

        // D�placement gauche
        if (Input.mousePosition.x < edgeThreshold)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }

        // D�placement droite
        if (Input.mousePosition.x > Screen.width - edgeThreshold)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }

        // D�placement bas
        if (Input.mousePosition.y < edgeThreshold)
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed, Space.World);
        }

        // D�placement haut
        if (Input.mousePosition.y > Screen.height - edgeThreshold)
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.orthographicSize > minDistance)
            {
                Camera.main.orthographicSize -= 1;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.orthographicSize < maxDistance)
                Camera.main.orthographicSize += 1;
        }
    }


}
