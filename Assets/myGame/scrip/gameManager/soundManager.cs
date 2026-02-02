using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager _instance;

    public static soundManager Instance
    {
        get => _instance;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }




    [Header("Audio Sources")]
    public AudioSource pop;
    public AudioSource Nijika_ahh;
    public AudioSource Snack;
    public AudioSource RioEat;

    public AudioSource BackGroundMusic;
    public void setPlayPop(AudioClip clip)
    {
        pop.PlayOneShot(clip);
    }

    public void setNijika_ahh(AudioClip clip)
    {
        Nijika_ahh.PlayOneShot(clip);
    }

    public void setRioEat(AudioClip clip)
    {
        RioEat.PlayOneShot(clip);
    }

    public void setSnack(AudioClip clip)
    {
        Snack.PlayOneShot(clip);
    }

    public void setBackGroundMusic(AudioClip clip)
    {
        BackGroundMusic.clip = clip;
        BackGroundMusic.Play();
    }
}
