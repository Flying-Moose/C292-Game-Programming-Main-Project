using UnityEngine;
using UnityEngine.UI;

public class FinishingTextDisplay : MonoBehaviour
{
    public Text finishingText;
    public GameObject player;
    private bool hardMode;
    public GameObject radio;
    public GameObject blackScreen;

    private float textTimer;
    private float textTimerMax = 17f;

    public GameObject bossSpriteSwitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackScreen.SetActive(false);
        textTimer = textTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().beatBoss && radio.activeSelf)
        {
            if (!player.GetComponent<PlayerController>().hardMode)
            {
                DisplayNonHard();
            }
            else
            {
                DisplayHard();
            }
        }
    }

    private void DisplayNonHard()
    {
        if (textTimer > 14)
        {
            player.GetComponent<PlayerController>().disablePlayerMovement = true;
            bossSpriteSwitch.GetComponent<BossSpriteSwitcher>().beatHard = true;
            blackScreen.SetActive(true);
            finishingText.text = "Hey! What are you doing back here?";
            textTimer -= Time.deltaTime;
        }
        else if (textTimer > 11)
        {
            finishingText.text = "What did you...";
            textTimer -= Time.deltaTime;
        }
        else if (textTimer > 7)
        {
            finishingText.text = "...";
            textTimer -= Time.deltaTime;
        }
        else if (textTimer > 4)
        {
            finishingText.text = "*sigh*";
            textTimer -= Time.deltaTime;
        }
        else if (textTimer > 1)
        {
            finishingText.text = "Well, now do you see why I said...";
            textTimer -= Time.deltaTime;
        }
        else
        {
            finishingText.text = " ";
            blackScreen.SetActive(false);
            textTimer = textTimerMax;
            player.GetComponent<PlayerController>().disablePlayerMovement = false;
            player.GetComponent<PlayerController>().beatBoss = false;
        }
    }
    private void DisplayHard()
    {
        if (textTimer > 14)
        {
            player.GetComponent<PlayerController>().disablePlayerMovement = true;
            bossSpriteSwitch.GetComponent<BossSpriteSwitcher>().beatHard = true;
            blackScreen.SetActive(true);
            finishingText.text = "Hey! What are you...";
            textTimer -= Time.deltaTime;
        }
        else if (textTimer > 11)
        {
            finishingText.text = "...";
            textTimer -= Time.deltaTime;
        }
        else if (textTimer > 7)
        {
            finishingText.text = "...You.. how did you...";
            textTimer -= Time.deltaTime;
        }
        else if (textTimer > 4)
        {
            finishingText.text = "...";
            textTimer -= Time.deltaTime;
        }
        else if (textTimer > 1)
        {
            finishingText.text = "..NOW do you see why I said...";
            textTimer -= Time.deltaTime;
        }
        else
        {
            finishingText.text = " ";
            blackScreen.SetActive(false);
            textTimer = textTimerMax;
            player.GetComponent<PlayerController>().disablePlayerMovement = false;
            player.GetComponent<PlayerController>().beatBoss = false;
        }
    }


}
