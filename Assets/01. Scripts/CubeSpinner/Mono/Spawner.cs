using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public  GameObject  simpleCube;
    private int         spawnCount = 300000;
    private float       halfWidth = 50f;
    private float       halfHeight = 50f;


    // Start is called before the first frame update
    void Start()
    {
        makeInstance();
    }

    void makeInstance()
    {
        for (int i = 0; i< spawnCount; ++i)
        {
            Debug.Log(i);
            Vector3 pos = new Vector3(Random.Range(-halfWidth, halfWidth), Random.Range(-halfWidth, halfWidth), Random.Range(-halfHeight, halfHeight));

            var temp = Instantiate(simpleCube, pos, Quaternion.identity);
            temp.transform.name = "Cube_Mono (" + i + ")";
        }
    }
}
