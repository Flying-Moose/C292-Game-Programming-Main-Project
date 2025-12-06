using UnityEditor.Animations;
using UnityEngine;

public class BossSpriteSwitcher : MonoBehaviour
{
    public GameObject country;
    public GameObject classical;
    public GameObject flamenco;
    public GameObject countrySingle;
    public GameObject classicalSingle;
    public GameObject flamencoSingle;
    public GameObject radio;

    private float inbetweenTimer;
    private bool timerSetterCO;
    private bool timerSetterCL;
    private bool timerSetterFL;

    public SpriteRenderer countrySpriteRenderer;
    public Sprite countryIdle;
    public Sprite countryShoot1;
    public Sprite countryShoot2;
    public Sprite countryKnifeSwipe;
    public Sprite countryBanjo1;
    public Sprite countryBanjo2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (radio.activeSelf)
        {
            inbetweenTimer = 0;
            timerSetterCO = true;
            timerSetterCL = true;
            timerSetterFL = true;

        } 
        else if (country.activeSelf)
        {
            if (timerSetterCO)
            {
                inbetweenTimer = 32;
                timerSetterCO = false;
            }
            CountrySpriteMovement();
        }
        else if (classical.activeSelf)
        {
            if (timerSetterCL)
            {
                inbetweenTimer = 32;
                timerSetterCL = false;
            }
            ClassicalSpriteMovement();
        }
        else if (flamenco.activeSelf)
        {
            if (timerSetterCO)
            {
                inbetweenTimer = 32;
                timerSetterFL = false;
            }
            FlamencoSpriteMovement();
        }

        void CountrySpriteMovement()
        {
            if (inbetweenTimer > 30)
            {
                
            }
            else if (inbetweenTimer > 29.8)
            {
                country.transform.position = new Vector3(0, 20);
                countrySingle.transform.position = new Vector3(0, 3.7f);
                countrySpriteRenderer.sprite = countryShoot1;
            }
            else if (inbetweenTimer > 29.3)
            {
                countrySpriteRenderer.sprite = countryShoot2;
            }
            else if (inbetweenTimer > 29.2)
            {
                country.transform.position = new Vector3(0, 3.7f);
                countrySingle.transform.position = new Vector3(0, 20);
                countrySpriteRenderer.sprite = countryIdle;
            }
            else if (inbetweenTimer > 28)
            {
                country.transform.position += Vector3.left * Time.deltaTime * 9;
                countrySingle.transform.position += Vector3.left * Time.deltaTime * 9;
            }
            else if (inbetweenTimer > 26.3)
            {

            }
            else if (inbetweenTimer > 25.3)
            {
                countrySpriteRenderer.sprite = countryKnifeSwipe;
                country.transform.position = new Vector3(0, 20);
                countrySingle.transform.position = new Vector3(0, 3.7f);
            }
            else if (inbetweenTimer > 20)
            {
                country.transform.position = new Vector3(0, 3.7f);
                countrySingle.transform.position = new Vector3(0, 20);
            }
            else if (inbetweenTimer > 17)
            {
                countrySpriteRenderer.sprite = countryBanjo1;
                country.transform.position = new Vector3(0, 20);
                countrySingle.transform.position = new Vector3(0, 3.7f);
            }
        }
        void ClassicalSpriteMovement()
        {

        }
        void FlamencoSpriteMovement()
        {

        }


        if (inbetweenTimer > 0)
        {
            inbetweenTimer -= Time.deltaTime * 2;
        }
    }
}
