using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Text = UnityEngine.UI.Text;

public class Logic : MonoBehaviour
{
    public int level;
    private int random;
    private int currentlyReachedCube = 0;
    private int score;

    public Button Startbutton;
    public ClickButton[] Cubes;
    public PositionChange position;
    public List<int> Numbers;

    public Text ScoreText;
    public Text GameOverText;

    public float showtime = 0.5f;
    public float pausetime = 0.5f;

    public bool player = false;
    private bool robot = false;

    // Start is called before the first frame update
    void Start()
    {
        position.shuffleCubes();
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
        score = 0;
        level = 1;
        Startbutton.interactable = false;
        ScoreText.text = score.ToString();
    }

    void GameOver(){
        Debug.Log("Game is over");
        GameOverText.text = "Game Over";
        Startbutton.interactable = true;
    }

    void CubeClicked(int _number){
        if(player) {
            if(_number == Numbers[currentlyReachedCube]){
                currentlyReachedCube += 1;
                score += 1;
                ScoreText.text = score.ToString();
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
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < level; i++)
        {
            if(Numbers.Count < level){
                random = Random.Range(0, Cubes.Length);
                Numbers.Add(random);
            }
             // turn on the corrisponding lights for this level then turn them off
            Cubes[Numbers[i]].HighlightNumber();
            yield return new WaitForSeconds(showtime);

            Cubes[Numbers[i]].UnclickedColor();
            yield return new WaitForSeconds(pausetime);
        }
        player = true;
    }
}
