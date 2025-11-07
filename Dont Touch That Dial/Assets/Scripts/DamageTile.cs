using Unity.VisualScripting;
using UnityEngine;

public class DamageTile : MonoBehaviour
{

    public GameObject damageTile;
    public float damageInbetweenTimer = 5;
    private int randX;
    private int randY;
    private Vector2 damageTileNewPosition;
    private bool readyToCountDown;
    private bool stopDamageTile;

    private int bossHealth = 15;
    public GameObject country;
    public GameObject classical;
    public GameObject flamenco;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damageTileNewPosition.y = 15;
        damageTile.gameObject.transform.position = damageTileNewPosition;
        readyToCountDown = true;
        classical.SetActive(false);
        country.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToCountDown)
        {
            if (damageInbetweenTimer > 0 && !stopDamageTile)
            {
                damageInbetweenTimer -= Time.deltaTime;
            }
            else
            {
                randX = Random.Range(-2, 2);
                randY = Random.Range(0, -4);
                damageTileNewPosition.x = randX;
                damageTileNewPosition.y = randY;
                damageTile.gameObject.transform.position = damageTileNewPosition;
                readyToCountDown = false;
            }
        }
    }
    private void DetectBossHealth()
    {
        if (bossHealth == 10)
        {
            country.SetActive(false);
            classical.SetActive(true);
        } 
        else if (bossHealth == 5)
        {
            classical.SetActive(false);
            flamenco.SetActive(true);
        } else if (bossHealth == 0)
        {
            flamenco.SetActive(false);
            stopDamageTile = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            damageTileNewPosition.y = 15;
            damageTile.gameObject.transform.position = damageTileNewPosition;
            Debug.Log("Damaged the boss!");
            bossHealth -= 1;
            DetectBossHealth();
            damageInbetweenTimer = 5;
            readyToCountDown = true;
        }
    }
}
