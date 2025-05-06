using UnityEngine;

public class Ball : MonoBehaviour
{
    Material material;
    Vector3 randomPos; // random position
    private void OnEnable() // call this void at prefab enable in hierarchy
    {
        material = GetComponent<Renderer>().material; // get prefab material
        randomPos = new Vector3 (Random.Range(-10f, 10f), .5f, Random.Range(-10f, 10f)); // set position to any point at 10 unit^2 area
        transform.localPosition = randomPos; // set prefab position to above value
        material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f)); // set prefab material color to random
    }

    private void OnMouseDown() // deactivate prefab at mouse click
    {
        gameObject.SetActive(false);
    }
}
