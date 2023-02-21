using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer vPlayer1;
    public VideoPlayer vPlayer2;
    public bool watchedAds;

    private void Awake()
    {
        vPlayer1 = vPlayer1.GetComponent<VideoPlayer>();
        vPlayer2 = vPlayer2.GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(!watchedAds)
        {
            vPlayer1.Play();
            watchedAds = true;
        }
    }
}
