using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cam;

    void Start()
    {
        // Récupère la caméra principale au démarrage
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Aucune caméra principale (MainCamera) n'a été trouvée !");
        }
    }

    void LateUpdate()
    {
        if (cam != null)
        {
            // Oriente le panneau vers la caméra
            transform.LookAt(transform.position + cam.forward);
        }
    }
}
