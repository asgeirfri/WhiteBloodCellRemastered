using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minWait;
    public float maxWait;

    public GameObject[] enemyTypes;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello BITCH");
        StartCoroutine(SpawnInSeconds(Random.Range(minWait, maxWait)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnInSeconds(float seconds)
    {
        Debug.Log("Hello");
        yield return new WaitForSeconds(seconds);
        Spawn();
        StartCoroutine(SpawnInSeconds(Random.Range(minWait, maxWait)));
    }

    void Spawn()
    {
        Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length - 1)], transform.position, Quaternion.identity);
    }
}
