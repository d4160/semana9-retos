using UnityEngine;
using UnityEngine.Audio;

public enum AudioType
{
    Master,
    Music,
    Ambience,
    SFX,
    Voice
}

public class AudioManager : MonoBehaviour
{
    public string masterVolumeParam = "MasterVolume";
    public float musicTransitionSpeed = 1f;

    [Header("References")]
    public AudioMixer audioMixer;
    public AudioSource musicSource;
    public AudioSource ambienceSource;
    public AudioSource sfxSource;
    public AudioSource voiceSource;

    private AudioClip _musicToChange = null;
    private float _musicVolume;

    public static AudioManager Instance { get; private set; }

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

    void Start()
    {
        _musicVolume = musicSource.volume;
    }

    void Update()
    {
        if (!_musicToChange)
        {
            musicSource.volume = Mathf.Lerp(musicSource.volume, _musicVolume, Time.deltaTime * musicTransitionSpeed);
            return;
        }

        musicSource.volume = Mathf.Lerp(musicSource.volume, 0f, Time.deltaTime * musicTransitionSpeed);

        if (musicSource.volume <= 0.01f)
        {
            musicSource.volume = 0;
            musicSource.clip = _musicToChange;
            musicSource.Play();

            _musicToChange = null;
        }
    }

    public void PlayAudio(AudioClip clip, AudioType audioType, Vector3? position = null)
    {
        switch (audioType)
        {
            case AudioType.Music:
                if (musicSource.clip != null)
                {
                    _musicToChange = clip;
                }
                else
                {
                    musicSource.clip = clip;
                    musicSource.Play();
                }
                break;
            case AudioType.Ambience:
                musicSource.clip = clip;
                musicSource.Play();
                break;
            case AudioType.SFX:
                if (position.HasValue)
                    sfxSource.transform.position = position.Value;
                sfxSource.PlayOneShot(clip);
                break;
            case AudioType.Voice:
                if (position.HasValue)
                    voiceSource.transform.position = position.Value;
                voiceSource.PlayOneShot(clip);
                break;
        }
    }

    public void ControlVolume(float volume)
    {
        audioMixer.SetFloat(masterVolumeParam, volume);
    }
}
