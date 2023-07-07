using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlocksSpawn : MonoBehaviour
{
    private System.Random _random = new System.Random();
    public GameObject[] blocks;
    private float[] poss = { 3.3f, 0f, -3.3f };
    // 3,-3, 0
    void Start()
    {
        Shuffle(poss);
        for (int i = 0; i < blocks.Length; i++) 
        {
            GameObject go = Instantiate(blocks[i], transform.position, Quaternion.identity);
            go.transform.SetParent(gameObject.transform);
            go.transform.position = gameObject.transform.position + new Vector3(0, poss[i], 0);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shuffle(float[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = _random.Next(0, n);
            float t = array[r];
            array[r] = array[n];
            array[n] = t;
        }
    }
}
