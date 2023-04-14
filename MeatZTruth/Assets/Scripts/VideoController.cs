using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using PixelCrushers.DialogueSystem;

public class VideoController : MonoBehaviour
{
    public GameObject cToughts;
    public VideoPlayer vPlayer1;
    static public bool watchedAds;
    public AudioSource BGM;

    private void Awake()
    {
        vPlayer1 = vPlayer1.GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        BGM = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        vPlayer1.loopPointReached += stopVideo;
        if (Input.GetKeyDown(KeyCode.K))
        {
            skipVideo();
        }
    }

    private void OnMouseDown()
    {
        if(!watchedAds)
        {
            vPlayer1.Play();
            BGM.Pause();
        }
    }
    void stopVideo(VideoPlayer vp)
    {
        watchedAds = true;
        DialogueLua.SetVariable("WatchAds", true);
        DialogueLua.SetVariable("Started", true);
        vp.Stop();
        cToughts.gameObject.SetActive(true);
        BGM.Play();
    }

    void skipVideo()
    {
        watchedAds = true;
        DialogueLua.SetVariable("WatchAds", true);
        DialogueLua.SetVariable("Started", true);
        vPlayer1.Stop();
        cToughts.gameObject.SetActive(true);
        BGM.Play();
    }
}
