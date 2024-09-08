using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.scoreChanged += onScoreChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onScoreChange(uint newScore)
    {
        score.text = "Score: " + newScore;
    }
}
