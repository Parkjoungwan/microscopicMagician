using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatControll : MonoBehaviour
{
    public GameStartController isPlaying;
    public TextMeshProUGUI statText;
    public AfterTimer afterTimer;
    private bool started = false;

    // Update is called once per frame
    void Update()
    {
        if (!started && isPlaying.isPlaying())
        {
            started = true;
            statText.text = "<color=white>Type!!</color>";
        }
        if (started && !isPlaying.isPlaying() && GameManager.playerScore != 2) 
        {
            statText.text = "<color=yellow>???????</color>";
        }
        if (started && !isPlaying.isPlaying() && GameManager.playerScore == 2) 
        {
            statText.text = "<color=yellow>!!!!!!!</color>";
        }
    }
}
