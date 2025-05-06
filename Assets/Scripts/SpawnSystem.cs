using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Average Object Pooling system
public class SpawnSystem : MonoBehaviour
{
    public static SpawnSystem Call; // singleton instance

    [SerializeField] GameObject ball; // object to pool (OTP)
    List<GameObject> balls = new(); // list for OTP clones
    public int maxBalls; // max OTP clones
    private void Awake()
    {
        Call = this;
        StartCoroutine(InstBalls());
    }

    public IEnumerator InstBalls()
    {
        for (int i = 0; i < maxBalls; i++) // for loop to add OTP clones to list
        {
            GameObject b = Instantiate(ball,transform); //instantiate clones
            balls.Add(b); // add clone to list
            b.SetActive(false); // set clone to inactive
            yield return b;
        }
    }
    public GameObject RetrieveBall() //activate OTP clone if not
    {
        for(int i = 0; i < balls.Count;i++) // for loop to read the list and
        {
            if (!balls[i].activeInHierarchy) //search for inactive OTP clones. If clone at list index is not active,
            {
                balls[i].SetActive(true); // set it active
                return balls[i]; // and return it
            }
        } return null; // otherwise, return null
    }
}
