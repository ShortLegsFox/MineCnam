using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public float speed = 10f;
    public float edgeThreshold = 10f;
    public float zoomSpeed = 2;
    public int limitXMin = -25;
    public int limitXMax = 25;
    public int limitZMin = -25;
    public int limitZMax = 25;


    void Update()
    {

        // Déplacement gauche
        if (Input.mousePosition.x < edgeThreshold)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }

        // Déplacement droite
        if (Input.mousePosition.x > Screen.width - edgeThreshold)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }

        // Déplacement bas
        if (Input.mousePosition.y < edgeThreshold)
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed, Space.World);
        }

        // Déplacement haut
        if (Input.mousePosition.y > Screen.height - edgeThreshold)
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed, Space.World);
        }

        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, limitXMin, limitXMax);
        newPosition.z = Mathf.Clamp(newPosition.z, limitZMin, limitZMax);

        // Appliquer la position corrigée
        transform.position = newPosition;


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - scroll * zoomSpeed, 5, 80);
        }

    }


}
