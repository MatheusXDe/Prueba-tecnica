using UnityEngine;

public class Ball : MonoBehaviour
{
    Material material;
    Vector3 randomPos;
    private void OnEnable()
    {
        material = GetComponent<Renderer>().material;
        randomPos = new Vector3 (Random.Range(-10f, 10f), .5f, Random.Range(-10f, 10f));
        transform.localPosition = randomPos;
        material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
    private void OnDisable()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
