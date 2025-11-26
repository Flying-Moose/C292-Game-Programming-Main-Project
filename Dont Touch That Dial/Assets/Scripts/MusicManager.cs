using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource country;
    public AudioSource waltz;
    public AudioSource tango;

    public GameObject radioSprite;
    public GameObject countrySprite;
    public GameObject classicalSprite;
    public GameObject flamencoSprite;

    private bool stopFromContinouslyPlaying;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        country.volume = 0;
        waltz.volume = 0;
        tango.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (radioSprite.activeSelf)
        {
            StopTracks();
            stopFromContinouslyPlaying = false;
            country.volume = 0;
            waltz.volume = 0;
            tango.volume = 0;
        }
        else if (countrySprite.activeSelf)
        {
            if (!stopFromContinouslyPlaying)
            {
                PlayTracks();
            }
            country.volume = 1;
        }
        else if (classicalSprite.activeSelf)
        {
            country.volume = 0;
            waltz.volume = 1;
        }
        else if (flamencoSprite.activeSelf)
        {
            waltz.volume = 0;
            tango.volume = 1;
        }
    }
    void PlayTracks()
    {
        country.Play();
        waltz.Play();
        tango.Play();
        stopFromContinouslyPlaying = true;
    }
    void StopTracks()
    {
        country.Stop();
        waltz.Stop();
        tango.Stop();
    }
}
