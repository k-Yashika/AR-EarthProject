using System.Collections;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject[] objectsToDelete; // An array of game objects to delete when deforestation occurs
    public float deletionDelay = 0.5f; // Delay between object deletions (in seconds)

    private int currentObjectIndex = 0;

    public void StartDeforestationProcess()
    {
        if (currentObjectIndex < objectsToDelete.Length)
        {
            StartCoroutine(GradualDeletion());
        }
    }

    private IEnumerator GradualDeletion()
    {
        yield return new WaitForSeconds(deletionDelay);

        if (currentObjectIndex < objectsToDelete.Length)
        {
            Destroy(objectsToDelete[currentObjectIndex]);
            currentObjectIndex++;

            // Check if there are more objects to delete
            if (currentObjectIndex < objectsToDelete.Length)
            {
                StartCoroutine(GradualDeletion());
            }
        }
    }
}
