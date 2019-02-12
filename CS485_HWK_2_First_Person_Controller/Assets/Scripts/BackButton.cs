using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public int buttonWidth;
    public int buttonHeight;
    private int origin_x;
    private int origin_y;

    private AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        buttonWidth = 100;
        buttonHeight = 30;
        origin_x = Screen.width - buttonWidth - 20;
        origin_y = Screen.height/5 - buttonHeight * 4;
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.loop = true;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(origin_x, origin_y, buttonWidth, buttonHeight), "Main Menu"))
        {
            Application.LoadLevel(0);
        }

    }
}
