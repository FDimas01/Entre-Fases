using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playButton;
    public Button pauseButton;
    public Button fullscreenButton;

    void Start()
    {
        // Ações dos botões
        playButton.onClick.AddListener(PlayVideo);
        pauseButton.onClick.AddListener(PauseVideo);
        fullscreenButton.onClick.AddListener(ToggleFullscreen);
    }

    void PlayVideo()
    {
        if (!videoPlayer.isPlaying)
            videoPlayer.Play();
    }

    void PauseVideo()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
    }

    void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
