using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScorePlayer : MonoBehaviour
{
    public float PlayerScore = 100;
    public Text ScoreText;
    public GameObject Player;

    public static ScorePlayer instance;

    // Start is called before the first frame update

    private void Awake(){
                instance = this;

    }
    void Start()
    {
        ScoreText.text = "" + PlayerScore;
    }

    // Update is called once per frame
    void Update()
    {
                ScoreText.text = "" + PlayerScore;

    }
}
