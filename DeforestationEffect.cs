using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeforestationEffect : MonoBehaviour
{
    public GameObject[] objectsToDelete; 
    public float deletionDelay = 0.5f; 

    private int currentObjectIndex = 0;

    public void StartDeforestationProcess()
    {
        StartCoroutine(GradualDeletion());
    }

    private IEnumerator GradualDeletion()
    {
        while (currentObjectIndex < objectsToDelete.Length)
        {
            yield return new WaitForSeconds(deletionDelay);

            if (currentObjectIndex < objectsToDelete.Length)
            {
                Destroy(objectsToDelete[currentObjectIndex]);
                currentObjectIndex++;
            }
        }
    }
}
