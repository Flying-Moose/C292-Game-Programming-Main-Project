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

    public SpriteRenderer classicalSpriteRenderer;
    public Sprite classicalIdle;
    public Sprite classicalThrow1;
    public Sprite classicalThrow2;
    public Sprite classicalStand;
    public Sprite classicalPaper1;
    public Sprite classicalPaper2;
    public Sprite classicalCatch;


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
            countrySingle.transform.position = new Vector3(0, 20);
            classicalSingle.transform.position = new Vector3(0, 20);
            flamencoSingle.transform.position = new Vector3(0, 20);

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
                inbetweenTimer = 52;
                timerSetterCL = false;
                countrySingle.transform.position = new Vector3(0, 20);
            }
            ClassicalSpriteMovement();
        }
        else if (flamenco.activeSelf)
        {
            if (timerSetterFL)
            {
                inbetweenTimer = 52;
                timerSetterFL = false;
                classicalSingle.transform.position = new Vector3(0, 20);
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
            else if (inbetweenTimer > 28)
            {
                countrySpriteRenderer.sprite = countryIdle;
                country.transform.position += Vector3.left * Time.deltaTime * 7;
                countrySingle.transform.position += Vector3.left * Time.deltaTime * 7;
            }
            else if (inbetweenTimer > 26.3)
            {

            }
            else if (inbetweenTimer > 25.5)
            {
                countrySpriteRenderer.sprite = countryKnifeSwipe;
                country.transform.position = new Vector3(0, 20);
                countrySingle.transform.position = new Vector3(0, 3.7f);
            }
            else if (inbetweenTimer > 16)
            {
                country.transform.position = new Vector3(0, 3.7f);
                countrySingle.transform.position = new Vector3(0, 20);
            }
            else if (inbetweenTimer > 13.5)
            {
                countrySpriteRenderer.sprite = countryBanjo1;
                country.transform.position = new Vector3(0, 20);
                countrySingle.transform.position = new Vector3(0, 3.7f);
            }
            else if (inbetweenTimer > 12.5)
            {
                countrySpriteRenderer.sprite = countryBanjo2;
            }
            else if (inbetweenTimer > 11.5)
            {
                country.transform.position = new Vector3(0, 3.7f);
                countrySingle.transform.position = new Vector3(0, 20);
            }
            else if (inbetweenTimer > 10)
            {
                inbetweenTimer = 30;
            }
        }
        void ClassicalSpriteMovement()
        {
            if (inbetweenTimer > 50)
            {
                
            }
            else if (inbetweenTimer > 49.9)
            {
                classical.transform.position = new Vector3(0, 3.7f);
            }
            else if (inbetweenTimer > 48.5)
            {
                classical.transform.position += Vector3.left * Time.deltaTime * 5;
                classicalSingle.transform.position += Vector3.left * Time.deltaTime * 5;
            }
            else if (inbetweenTimer > 34)
            {

            }
            else if (inbetweenTimer > 33)
            {
                classical.transform.position = new Vector3(classical.transform.position.x, 20);
                classicalSingle.transform.position = new Vector3(classical.transform.position.x, 3.7f);
                classicalSpriteRenderer.sprite = classicalThrow1;
            }
            else if (inbetweenTimer > 32)
            {
                classicalSpriteRenderer.sprite = classicalThrow2;
            }
            else if (inbetweenTimer > 31)
            {
                classicalSpriteRenderer.sprite = classicalStand;
            }
            else if (inbetweenTimer > 27.9)
            {
                
            }
            else if (inbetweenTimer > 26.5)
            {
                classical.transform.position += Vector3.right * Time.deltaTime * 5;
                classicalSingle.transform.position += Vector3.right * Time.deltaTime * 5;
            }
            else if (inbetweenTimer > 14)
            {
                
            }
            else if (inbetweenTimer > 12)
            {
                classicalSpriteRenderer.sprite = classicalPaper1;
            }
            else if (inbetweenTimer > 11)
            {
                classicalSpriteRenderer.sprite = classicalPaper2;
            }
            else if (inbetweenTimer > 10)
            {
                classicalSpriteRenderer.sprite = classicalStand;
            }
            else if (inbetweenTimer > 9)
            {
                
            }
            else if (inbetweenTimer > 8)
            {
                classicalSpriteRenderer.sprite = classicalCatch;
            }
            else if (inbetweenTimer > 7)
            {
                classical.transform.position = new Vector3(0, 3.7f);
                classicalSingle.transform.position = new Vector3(0, 20);
            }
            else if (inbetweenTimer > 1)
            {

            }
            else if (inbetweenTimer > 0)
            {
                inbetweenTimer = 50;
            }
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
