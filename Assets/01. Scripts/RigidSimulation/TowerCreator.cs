using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerCreator : MonoBehaviour
{
    public GameObject cubePrefab;

    public int length;
    public int width;
    public int height;
    public TextMeshProUGUI cubeCounter;
    private int cubeCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                for (int l = 0; l < length; l++)
                {

                    if (l != 0 && w != 0 && l != length - 1 && w != width - 1)
                    {
                        continue;
                    }
                    Instantiate(cubePrefab, new Vector3(l, h + 0.5f, w), Quaternion.identity);
                    cubeCount++;
                }
            }
        }
        cubeCounter.text = "" + cubeCount;
    }

}
