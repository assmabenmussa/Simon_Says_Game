using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public int level;
    public ClickButton[] Cubes;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Cubes.Length; i++)
        {
            Debug.Log("Cubes[i]", Cubes[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Logic(){
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < level; i++)
        {
            
        }
    }
}
