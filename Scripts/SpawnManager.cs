using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;

    public float minTime = 1f;
    public float maxTime = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCoRuntine(0));
    }

    IEnumerator SpawnCoRuntine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], transform.position, Quaternion.identity);
        StartCoroutine(SpawnCoRuntine(Random.Range(minTime, maxTime))); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
