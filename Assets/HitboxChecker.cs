using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxChecker : MonoBehaviour
{
    public enum Hitmarker {Left,Right}
    public Hitmarker hitmarkerType;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log("AnusLikker");

        if(hitmarkerType == Hitmarker.Left && other.gameObject.tag == "Player")
        {
            Debug.Log("Linkerhand Abi");
                ScorePlayer.instance.PlayerScore += 10;
                source.Play();

        }
        if(hitmarkerType == Hitmarker.Right && other.gameObject.tag == "Player")
        {
            Debug.Log("rechts Abi");
                ScorePlayer.instance.PlayerScore += 10;
                source.Play();

        }
    }
}
