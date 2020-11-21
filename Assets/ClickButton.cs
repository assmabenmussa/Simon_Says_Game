using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public Material DefaultColor;
    public Material HighlightColor;
    
    public int CubeNumber = 99;
    public bool UnclickedColorComplete = false;
    public delegate void ClickEvent(int CubeNumber);
    public event ClickEvent onClick;

    public AudioSource audio;
    public AudioClip number_recording;

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

    private void OnMouseDown () {
        ClickedColor();
        onClick.Invoke(CubeNumber);
        UnclickedColorComplete = false;
    }

    private void OnMouseUp() {
        UnclickedColor();
        UnclickedColorComplete = true;
    }

    public void ClickedColor(){
        renderer.sharedMaterial = HighlightColor;
    }

    public void HighlightNumber(){
        renderer.sharedMaterial = HighlightColor;
        audio.PlayOneShot(number_recording);
    }

    public void UnclickedColor(){
        renderer.sharedMaterial = DefaultColor;
    }


}
