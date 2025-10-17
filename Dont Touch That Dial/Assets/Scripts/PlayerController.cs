using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Vector2 currPlayerPosition = new Vector2(0,-2);
    private float upperBarrier = 0;
    private float lowerBarrier = -4;
    private float leftBarrier = -2;
    private float rightBarrier = 2;
    private bool disableUp;
    private bool disableDown;
    private bool disableLeft;
    private bool disableRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BarrierCheck();
        
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && !disableLeft){
            currPlayerPosition.x -= 1;
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !disableRight)
        {
            currPlayerPosition.x += 1;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !disableUp)
        {
            currPlayerPosition.y += 1;
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && !disableDown)
        {
            currPlayerPosition.y -= 1;
        }
        player.gameObject.transform.position = currPlayerPosition;
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
}
