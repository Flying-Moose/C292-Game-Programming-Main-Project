using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Vector3 currPlayerPosition = new Vector2(0,-2);
    private Vector3 moveDist = Vector3.zero;
    private float upperBarrier = 0;
    private float lowerBarrier = -4;
    private float leftBarrier = -2;
    private float rightBarrier = 2;
    private bool disableUp;
    private bool disableDown;
    private bool disableLeft;
    private bool disableRight;
    private bool moving = true;
    private float moveTimer;
    private float invulTimer = 0;
    private float health = 3;
    public SpriteRenderer spriteRenderer;
    public Sprite playerSprite;
    public Sprite upPlayerSprite;
    public Sprite downPlayerSprite;
    public Sprite LRPlayerSprite;
    public bool spriteFlip;
    private bool damaged;
    private float damageInbetweenTimer;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject radio;
    public GameObject country;
    public GameObject classical;
    public GameObject flamenco;

    public AudioSource damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BarrierCheck();
        
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && !disableLeft && !moving){
            currPlayerPosition.x -= 1;
            moveDist.x -= 1;
            spriteRenderer.flipX = false;
            spriteRenderer.sprite = LRPlayerSprite;
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !disableRight && !moving)
        {
            currPlayerPosition.x += 1;
            moveDist.x += 1;
            spriteRenderer.flipX = true;
            spriteRenderer.sprite = LRPlayerSprite;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !disableUp && !moving)
        {
            currPlayerPosition.y += 1;
            moveDist.y += 1;
            spriteRenderer.sprite = upPlayerSprite;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && !disableDown && !moving)
        {
            currPlayerPosition.y -= 1;
            moveDist.y -= 1;
            spriteRenderer.sprite = downPlayerSprite;
        }

        if (player.gameObject.transform.position != currPlayerPosition)
        {
            moving = true;
            Moving(moveDist);
            
        } else
        {
            moveDist = Vector3.zero;
            moving = false;
            spriteRenderer.sprite = playerSprite;
        }

        if (health <= 0)
        {
            country.SetActive(false);
            classical.SetActive(false);
            flamenco.SetActive(false);
            radio.SetActive(true);
        }
        if (radio.activeSelf)
        {
            health = 3;
        }

        if (health == 3 && !radio.activeSelf)
        {
            heart3.SetActive(true);
            heart2.SetActive(true);
            heart1.SetActive(true);
        } 
        else if (health == 2 && !radio.activeSelf)
        {
            heart3.SetActive(false);
            heart2.SetActive(true);
            heart1.SetActive(true);
        }
        else if (health == 1 && !radio.activeSelf)
        {
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(true);
        }
        else if (radio.activeSelf)
        {
            heart3.SetActive(false);
            heart2.SetActive(false);
            heart1.SetActive(false);
        }

        void Moving(Vector3 desiredMovement)
            {
                if (desiredMovement.x == -1 && player.gameObject.transform.position.x > currPlayerPosition.x)
                {
                    ActuallyMovePlayer();
                }
                else if (desiredMovement.x == 1 && player.gameObject.transform.position.x < currPlayerPosition.x)
                {
                    ActuallyMovePlayer();
                }
                else if (desiredMovement.y == -1 && player.gameObject.transform.position.y > currPlayerPosition.y)
                {
                    ActuallyMovePlayer();
                }
                else if (desiredMovement.y == 1 && player.gameObject.transform.position.y < currPlayerPosition.y)
                {
                    ActuallyMovePlayer();
                }
            }
        void ActuallyMovePlayer()
        {
            player.gameObject.transform.position += moveDist * Time.deltaTime * 5;
            moveTimer = 0.01f;
        }
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
        }
        else
        {
            player.gameObject.transform.position = new Vector3(Mathf.RoundToInt(player.gameObject.transform.position.x), Mathf.RoundToInt(player.gameObject.transform.position.y));
        }

        if (invulTimer > 0)
        {
            invulTimer -= Time.deltaTime;
        }
        if ((player.transform.position == Vector3.zero) && radio.activeSelf && (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W))))
        {
            country.SetActive(true);
            radio.SetActive(false);
        }

        if (damaged)
        {
            spriteRenderer.sprite = null;

            if (damageInbetweenTimer > 0)
            {
                damageInbetweenTimer -= Time.deltaTime;
            }
            else
            {
                spriteRenderer.sprite = playerSprite;
                damaged = false;
            }
        }
    }
    public void BarrierCheck()
    {
        if (player.gameObject.transform.position.y == upperBarrier){ disableUp = true; }
        else { disableUp = false; }
        if (player.gameObject.transform.position.y == lowerBarrier) { disableDown = true; }
        else { disableDown = false; }
        if (player.gameObject.transform.position.x == leftBarrier) { disableLeft = true; }
        else { disableLeft = false; }
        if (player.gameObject.transform.position.x == rightBarrier) { disableRight = true; }
        else { disableRight = false; }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Attack") && invulTimer <= 0)
        {
            damaged = true;
            damageInbetweenTimer = 0.1f;
            health -= 1;
            Debug.Log("ouchie!");
            invulTimer = 1;
            damage.Play();
        }
    }
}
