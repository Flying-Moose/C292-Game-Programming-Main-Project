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
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !disableRight && !moving)
        {
            currPlayerPosition.x += 1;
            moveDist.x += 1;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !disableUp && !moving)
        {
            currPlayerPosition.y += 1;
            moveDist.y += 1;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && !disableDown && !moving)
        {
            currPlayerPosition.y -= 1;
            moveDist.y -= 1;
        }

        if (player.gameObject.transform.position != currPlayerPosition)
        {
            moving = true;
            Moving(moveDist);
            
        } else
        {
            moveDist = Vector3.zero;
            moving = false;
        }

        void Moving(Vector3 desiredMovement)
        {
            if (desiredMovement.x == -1 && player.gameObject.transform.position.x > currPlayerPosition.x)
            {
                ActuallyMovePlayer();
            } else if (desiredMovement.x == 1 && player.gameObject.transform.position.x < currPlayerPosition.x)
            {
                ActuallyMovePlayer();
            } else if (desiredMovement.y == -1 && player.gameObject.transform.position.y > currPlayerPosition.y)
            {
                ActuallyMovePlayer();
            } else if (desiredMovement.y == 1 && player.gameObject.transform.position.y < currPlayerPosition.y)
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
            health -= 1;
            Debug.Log("ouchie!");
            invulTimer = 1;
        }
    }
}
