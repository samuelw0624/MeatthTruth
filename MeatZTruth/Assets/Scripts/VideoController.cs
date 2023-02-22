using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public GameObject cToughts;
    public VideoPlayer vPlayer1;
    public bool watchedAds;

    private void Awake()
    {
        vPlayer1 = vPlayer1.GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vPlayer1.loopPointReached += stopVideo;
    }

    private void OnMouseDown()
    {
        if(!watchedAds)
        {
            vPlayer1.Play();
        }
    }
    void stopVideo(UnityEngine.Video.VideoPlayer vp)
    {
        watchedAds = true;
        vp.Stop();
        cToughts.gameObject.SetActive(true);
    }
}
