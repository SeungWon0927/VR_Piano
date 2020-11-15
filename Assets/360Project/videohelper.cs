using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videohelper : MonoBehaviour
{
    private VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }
    public void play() 
    {
        player.Play();
    }
    public void pause()
    {
        player.Pause();

    }
    public void stop()
    {
        player.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
