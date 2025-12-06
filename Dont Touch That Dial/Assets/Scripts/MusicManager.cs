using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource country;
    public AudioSource waltz;
    public AudioSource tango;
    public AudioSource staticSound;

    public GameObject radioSprite;
    public GameObject countrySprite;
    public GameObject classicalSprite;
    public GameObject flamencoSprite;
    public GameObject staticSprite;

    public float inbetweenTimer = 1;
    private bool timerInitiater;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (staticSprite.transform.position == new Vector3(0, 3.1f) && timerInitiater)
        {
            if (!staticSound.isPlaying)
            {
                staticSound.Play();
            }
            inbetweenTimer = 1;
            timerInitiater = false;
            StopTracks();
        }
        if (radioSprite.activeSelf)
        {
            StopTracks();
            timerInitiater = true;
        }
        else if (countrySprite.activeSelf)
        {
            if (inbetweenTimer > 0)
            {
                inbetweenTimer -= Time.deltaTime;
            } 
            else if (!country.isPlaying && !timerInitiater)
            {
                country.Play();
                staticSound.Stop();
                timerInitiater = true;
            }
        }
        else if (classicalSprite.activeSelf)
        {
            if (inbetweenTimer > 0)
            {
                inbetweenTimer -= Time.deltaTime;
            }
            else if (!waltz.isPlaying && !timerInitiater)
            {
                waltz.Play();
                staticSound.Stop();
                timerInitiater = true;
            }
        }
        else if (flamencoSprite.activeSelf)
        {
            if (inbetweenTimer > 0)
            {
                inbetweenTimer -= Time.deltaTime;
            }
            else if (!tango.isPlaying && !timerInitiater)
            {
                tango.Play();
                staticSound.Stop();
                timerInitiater = true;
            }
        }
    }
    void StopTracks()
    {
        country.Stop();
        waltz.Stop();
        tango.Stop();
    }
}
