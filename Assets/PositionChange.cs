﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    public GameObject CubeWorld;
    private int i;
    public GameObject[] cubes;
    private List<Vector3> originalCubePositions = new List<Vector3>();
    private List<Vector3> newPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        for(i=0; i < cubes.Length; i++){
        originalCubePositions.Add(cubes[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Shuffle<T>(this IList<T> list)  
    {  
        Random rng = new Random();  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            T value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
        return list;
    }

    public void scatterCubes()
    {
        List<Vector3> shuffledPositions = Shuffle(originalCubePositions);
        Debug.Log("Starting scatter process before I kill him.");
        for(int j = 0; j < cubes.Length; j++){
            // cubes[j].transform.position.x = shuffledPositions[j].x;
            cubes[j].transform.position = new Vector3(shuffledPositions[j].x, cubes[j].transform.position.y, cubes[j].transform.position.z);
            Debug.Log("Scattering: " + cubes[j].transform.position.x + shuffledPositions[j].x);
        }
    }
}
