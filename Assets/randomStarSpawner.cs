using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomStarSpawner : MonoBehaviour
{
    public float minRange;
    public float maxRange;
    public float starCount;
    public GameObject starPrefab;
    // Start is called before the first frame update
    void Start()
    {
       // print(Vector3.Distance(Vector3.zero, new Vector3(20, 32, -4)));
        for (int i = 0; i < starCount; i++)
        {
            var spawnloc = Random.onUnitSphere * Random.Range(minRange, maxRange);
            Instantiate(starPrefab, spawnloc, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
