using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SphereMonoCreator : MonoBehaviour
{
    public GameObject spherePrefab;
    public int length;
    public int width;
    public int height;
    public TextMeshProUGUI sphereCounter;
    public Vector3 Offset;
    private int sphereCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {
                    //Instantiate(cubePrefab, new Vector3(l, h + 0.5f, w), Quaternion.identity);
                    Instantiate(spherePrefab, new Vector3(l + Offset.x, h + 0.5f + Offset.y, w + Offset.z), Quaternion.identity);
                    sphereCount++;
                }
            }
        }

        sphereCounter.text = "" + sphereCount * 2;
    }
}
