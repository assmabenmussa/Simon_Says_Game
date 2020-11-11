using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public int level;
    public int random;
    public ClickButton[] Cubes;
    public List<int> Numbers;
    public float showtime = 0.5f;
    public float pausetime = 0.5f;

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

    private IEnumerator gameLogic(){
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < level; i++)
        {
            if(Numbers.Count < level){
                random = Random.Range(0, Cubes.Length);
                Numbers.Add(random);
            }
             // turn on the corrisponding lights for this level then turn them off
            Cubes[Numbers[i]].ClickedColor();
            yield return new WaitForSeconds(showtime);

            Cubes[Numbers[i]].UnclickedColor();
            yield return new WaitForSeconds(pausetime);
        }
    }
}
