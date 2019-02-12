using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public int buttonWidth;
    public int buttonHeight;
    private int origin_x;
    private int origin_y;

    private AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        buttonWidth = 200;
        buttonHeight = 50;
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2;
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.loop = true;
    }

    // Update is called once per frame
    void OnGUI()
    {
        if(GUI.Button(new Rect(origin_x, origin_y, buttonWidth, buttonHeight), "PLAY"))
        {
            Application.LoadLevel(1);
        }

        if(GUI.Button(new Rect(origin_x, origin_y + 100, buttonWidth, buttonHeight), "QUIT"))
        {
            Application.Quit();
            Debug.Log("EXIT");
        }
    }
}
