using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    AudioSource audioSource;
    AudioClip currentClip;

    void Awake()
    {
        // Singleton simples
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Chame este método passando o clip do botão.
    /// </summary>
    public void PlayPauseClip(AudioClip clip)
    {
        // Se for o mesmo clip e estiver tocando → pausa
        if (clip == currentClip && audioSource.isPlaying)
        {
            audioSource.Pause();
            return;
        }

        // Se for o mesmo clip e estiver pausado → retoma
        if (clip == currentClip && !audioSource.isPlaying)
        {
            audioSource.Play();
            return;
        }

        // Se for clip diferente → troca e toca
        currentClip = clip;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
