﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        Debug.Log("Text cube clicked");
    }

    void OnMouseUp() {
        Debug.Log("Text cube declicked");
    }
}
