using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cam;

    void Start()
    {
        // R�cup�re la cam�ra principale au d�marrage
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning("Aucune cam�ra principale (MainCamera) n'a �t� trouv�e !");
        }
    }

    void LateUpdate()
    {
        if (cam != null)
        {
            // Oriente le panneau vers la cam�ra
            transform.LookAt(transform.position + cam.forward);
        }
    }
}
