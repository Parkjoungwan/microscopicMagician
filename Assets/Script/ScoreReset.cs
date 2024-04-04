using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GameManager.tryNum++;
       GameManager.ResetScore();
    }
}
