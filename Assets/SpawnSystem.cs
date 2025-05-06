using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public static SpawnSystem Call;

    [SerializeField] GameObject ball;
    List<GameObject> balls = new();
    public int maxBalls;
    private void Awake()
    {
        Call = this;
        StartCoroutine(InstBalls());
    }

    public IEnumerator InstBalls()
    {
        for (int i = 0; i < maxBalls; i++)
        {
            GameObject b = Instantiate(ball,transform);
            balls.Add(b);
            b.SetActive(false);
            yield return b;
        }
    }
    public GameObject RetrieveBall()
    {
        for(int i = 0; i < balls.Count;i++)
        {
            if (!balls[i].activeInHierarchy)
            {
                balls[i].SetActive(true);
                return balls[i];
            }
        } return null;
    }
}
