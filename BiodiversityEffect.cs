using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiodiversityEffect : MonoBehaviour
{
    public GameObject treePrefab; // Prefab of the tree to add
    public GameObject animalPrefab; // Prefab of the animal to add
    public int treesToAdd = 10; // Number of trees to add
    public int animalsToAdd = 5; // Number of animals to add
    public float objectAddDelay = 0.5f; // Delay between adding objects (in seconds)

    private int treesAdded = 0;
    private int animalsAdded = 0;

    public void AddBiodiversity()
    {
        if (treesAdded < treesToAdd)
        {
            StartCoroutine(GradualObjectAddition(treePrefab));
            treesAdded++;
        }
        else if (animalsAdded < animalsToAdd)
        {
            StartCoroutine(GradualObjectAddition(animalPrefab));
            animalsAdded++;
        }
    }

    private IEnumerator GradualObjectAddition(GameObject prefab)
    {
        while (true)
        {
            Instantiate(prefab, GetRandomPosition(), Quaternion.identity);

            if (prefab == treePrefab)
            {
                treesAdded++;
            }
            else if (prefab == animalPrefab)
            {
                animalsAdded++;
            }

            if ((treesAdded < treesToAdd || animalsAdded < animalsToAdd))
            {
                yield return new WaitForSeconds(objectAddDelay);
            }
            else
            {
                break;
            }
        }
    }

    // Helper method to get a random position at ground level
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-10f, 10f); // Adjust these values based on your scene
        float z = Random.Range(-10f, 10f);
        float y = GetGroundHeight(new Vector3(x, 0, z));

        return new Vector3(x, y, z);
    }

    // Helper method to determine the ground height using a raycast
    private float GetGroundHeight(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit))
        {
            return hit.point.y;
        }

        return 0f; // Default height if no ground is found
    }
}
