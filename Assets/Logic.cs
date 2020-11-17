using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Logic : MonoBehaviour
{
    public int level;
    private int random;
    private int currentlyReachedCube = 0;

    public Button Startbutton;
    public ClickButton[] Cubes;
    public List<int> Numbers;

    public float showtime = 0.5f;
    public float pausetime = 0.5f;

    public bool player = false;
    private bool robot = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Cubes.Length; i++)
        {
            Cubes[i].onClick += CubeClicked;
            Cubes[i].CubeNumber = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (robot)
        {
            robot = false;
            StartCoroutine(Robot());
        }
    }

    public void StartGame()
    {
        robot = true;
        currentlyReachedCube = 0;
        level = 1;
        Startbutton.interactable = false;
    }

    void GameOver(){
        Debug.Log("Game is over");
        Startbutton.interactable = true;
    }

    void CubeClicked(int _number){
        if(player) {
            if(_number == Numbers[currentlyReachedCube]){
                currentlyReachedCube += 1;
            }
            else{
                GameOver();
            }

            if (currentlyReachedCube == level){
                level += 1;
                currentlyReachedCube = 0;
                player = false;
                robot = true;
            }
        }
    }

    private IEnumerator Robot(){
        Debug.Log("running IEnumerator");
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
        player = true;
    }
}
