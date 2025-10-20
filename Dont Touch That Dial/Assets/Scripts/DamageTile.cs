using UnityEngine;

public class DamageTile : MonoBehaviour
{

    public GameObject damageTile;
    public float damageInbetweenTimer = 5;
    private int randX;
    private int randY;
    private Vector2 damageTileNewPosition;
    private bool readyToCountDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damageTileNewPosition.y = 15;
        damageTile.gameObject.transform.position = damageTileNewPosition;
        readyToCountDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToCountDown)
        {
            if (damageInbetweenTimer > 0)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            damageTileNewPosition.y = 15;
            damageTile.gameObject.transform.position = damageTileNewPosition;
            Debug.Log("Damaged the boss!");
            damageInbetweenTimer = 5;
            readyToCountDown = true;
        }
    }
}
