using System.Collections;
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

    public static void Shuffle<T>(IList<T> ts) {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public void shuffleCubes()
    {
        Shuffle(originalCubePositions);
        for(int j = 0; j < cubes.Length; j++){
            // cubes[j].transform.position.x = shuffledPositions[j].x;
            cubes[j].transform.position = new Vector3(originalCubePositions[j].x, cubes[j].transform.position.y, cubes[j].transform.position.z);
        }
    }
}
