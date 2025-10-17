using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    private Vector2 upperBarrier = Vector2.up;
    private Vector2 lowerBarrier = Vector2.down;
    private Vector2 leftBarrier = Vector2.left;
    private Vector2 rightBarrier = Vector2.right;
    private Vector2 currPlayerPosition = new Vector2(0,-2);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            currPlayerPosition.x -= 1;
            Debug.Log("left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            currPlayerPosition.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            currPlayerPosition.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            currPlayerPosition.y -= 1;
        }
        player.gameObject.transform.position = currPlayerPosition;
    }
}
