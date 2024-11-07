using UnityEngine;

public class MusicPlayList : MonoBehaviour
{
    public AudioClip[] musicClips;

    public static MusicPlayList Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayMusic(int index)
    {
        if (index < 0 || index >= musicClips.Length)
            return;

        AudioManager.Instance.PlayAudio(musicClips[index], AudioType.Music);
    }
}
