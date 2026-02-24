using UnityEngine;
using System.Collections.Generic;

public class Playground : MonoBehaviour
{
    public GameObject cube;
    public List<string> names;
    public BV.Range cooldown;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cube.gameObject.GetComponent<Renderer>().material.color = ColorX.GetRandomColor();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            ListX.ShuffleList(names);
            Debug.Log(names[0]);
        }
    }
}
