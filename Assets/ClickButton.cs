using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public Material DefaultColor;
    public Material HighlightColor;
    public delegate void ClickEvent(int number);
    public event ClickEvent onClick;
    public int CubeNumber = 99;

    public Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown () {
        ClickedColor();
        onClick.Invoke(CubeNumber);
    }

    void OnMouseUp() {
        UnclickedColor();
    }

    void ClickedColor(){
        renderer.sharedMaterial = HighlightColor;
    }

    void UnclickedColor(){
        renderer.sharedMaterial = DefaultColor;
    }


}
