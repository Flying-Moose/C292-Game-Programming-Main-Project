using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public GameObject COsprite;
    public GameObject CLsprite;
    public GameObject FLsprite;
    public GameObject radioSprite;

    public GameObject CObullet;
    public GameObject COsplitBullet1;
    public GameObject COsplitBullet2;
    public GameObject COslash;
    public GameObject CObomb;
    public GameObject COboom;
    public GameObject CObanjoswipe;

    public GameObject CLlines;
    public GameObject CLnote1;
    public GameObject CLnote2;
    public GameObject CLnote3;
    public GameObject CLflute;
    public GameObject CLpaper1;
    public GameObject CLpaper2;

    public GameObject FLfan;
    public GameObject FLfire;
    public GameObject FLpetal1;
    public GameObject FLpetal2;

    private float attackPause;
    private float randInt;
    private bool ifRand = true;

    GameObject bullet1 = null;
    GameObject bullet2 = null;
    GameObject bullet3 = null;
    GameObject splitBullet1 = null;
    GameObject splitBullet2 = null;
    GameObject swipe = null;
    GameObject bomb = null;
    GameObject bomb2 = null;
    GameObject blast = null;
    GameObject blast2 = null;
    GameObject banjoSwipe = null;

    GameObject stanza1 = null;
    GameObject stanza2 = null;
    GameObject note1 = null;
    GameObject note2 = null;
    GameObject note3 = null;
    GameObject flute = null;
    GameObject paper1 = null;
    GameObject paper2 = null;

    GameObject fan = null;
    GameObject fire1 = null;
    GameObject fire2 = null;
    GameObject petal1 = null;
    GameObject petal2 = null;
    GameObject petal3 = null;
    GameObject petal4 = null;

    public GameObject playerCamera;

    bool COInit = true;
    bool CLInit = true;
    bool FLInit = true;

    public GameObject COcollection;
    public GameObject CLcollection;
    public GameObject FLcollection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InstantiateEverything();
    }

    // Update is called once per frame
    void Update()
    {
        if (radioSprite.activeSelf)
        {
            playerCamera.transform.eulerAngles = Vector3.zero;
            FLcollection.SetActive(false);
        }
        else if (COsprite.activeSelf)
        {
            if (COInit)
            {
                COcollection.SetActive(true);
                attackPause = 30;
                CLInit = true;
                COInit = false;
            }
            COAttacks();
        } 
        else if (CLsprite.activeSelf)
        {
            if (CLInit)
            {
                CLcollection.SetActive(true);
                COcollection.SetActive(false);
                attackPause = 50;
                FLInit = true;
                CLInit = false;
            }
            CLAttacks();
        } 
        else if (FLsprite.activeSelf)
        {
            if (FLInit)
            {
                FLcollection.SetActive(true);
                CLcollection.SetActive(false);
                fire2.transform.eulerAngles = new Vector3(0, 0, 180);
                attackPause = 50;
                COInit = true;
                FLInit = false;
            }
            FLAttacks();
        }

            void COAttacks()
            {
                if (attackPause > 26.4)
                {
                    OneRandom(0, -4);
                    bomb.transform.position = new Vector3(-15, randInt);
                    bullet1.transform.position += Vector3.down * Time.deltaTime * 7;
                    bullet2.transform.position += Vector3.down * Time.deltaTime * 7;
                    bullet3.transform.position += Vector3.down * Time.deltaTime * 7;
                }
                else if (attackPause > 25.9)
                {
                    ifRand = true;
                    bullet2.gameObject.transform.position = new Vector3(0, 10);
                    bullet1.transform.position += Vector3.down * Time.deltaTime * 7;
                    bullet3.transform.position += Vector3.down * Time.deltaTime * 7;
                    swipe.gameObject.transform.position = new Vector3(0, -2);
                    splitBullet1.transform.eulerAngles = Vector3.zero;
                    splitBullet2.transform.eulerAngles = Vector3.zero;
                    splitBullet1.gameObject.transform.position = new Vector3(0, -3);
                    splitBullet2.gameObject.transform.position = new Vector3(0, -3);
                }
                else if (attackPause > 24)
                {
                    OneRandom(0, -4);
                    bomb2.transform.position = new Vector3(15, randInt);
                    bullet1.transform.position += Vector3.down * Time.deltaTime * 7;
                    bullet3.transform.position += Vector3.down * Time.deltaTime * 7;
                    splitBullet1.transform.position -= new Vector3(-0.5f, -1) * Time.deltaTime * 7;
                    splitBullet2.transform.position -= new Vector3(0.5f, 1) * Time.deltaTime * 7;
                    splitBullet1.transform.eulerAngles += new Vector3(0, 0, -40) * Time.deltaTime;
                    splitBullet2.transform.eulerAngles += new Vector3(0, 0, -40) * Time.deltaTime;
                    swipe.gameObject.transform.position = new Vector3(0, 10);
                }
                else if (attackPause > 20)
                {
                    ifRand = true;
                    splitBullet1.transform.eulerAngles += new Vector3(0, 0, -40) * Time.deltaTime;
                    splitBullet2.transform.eulerAngles += new Vector3(0, 0, -40) * Time.deltaTime;
                    splitBullet1.transform.position -= new Vector3(-0.5f, -1) * Time.deltaTime * 7;
                    splitBullet2.transform.position -= new Vector3(0.5f, 1) * Time.deltaTime * 7;
                    bomb.transform.position += Vector3.right * Time.deltaTime * 8;
                    bomb.transform.eulerAngles += new Vector3(0, 0, -30) * Time.deltaTime;
                }
                else if (attackPause > 19.5)
                {
                    bullet1.gameObject.transform.position = new Vector3(-2, 11);
                    bullet3.gameObject.transform.position = new Vector3(2, 11);
                    blast.transform.position = bomb.transform.position;
                    blast.transform.eulerAngles += new Vector3(0, 0, 30) * Time.deltaTime;
                    bomb.SetActive(false);
                }
                else if (attackPause > 15.5)
                {
                    bomb.SetActive(true);
                    bomb.transform.position = new Vector3(-15, -2);
                    blast.transform.position = new Vector3(-15, -2);
                    blast.transform.eulerAngles = Vector3.zero;
                    bomb2.transform.eulerAngles += new Vector3(0, 0, 20) * Time.deltaTime;
                    bomb2.transform.position += Vector3.left * Time.deltaTime * 8;
                }
                else if (attackPause > 15)
                {
                    blast2.transform.position = bomb2.transform.position;
                    blast2.transform.eulerAngles += new Vector3(0, 0, -30) * Time.deltaTime;
                    bomb2.SetActive(false);
                }
                else if (attackPause > 13.5)
                {
                    bomb2.SetActive(true);
                    bomb2.transform.position = new Vector3(15, -4);
                    blast2.transform.position = new Vector3(15, -4);
                    blast2.transform.eulerAngles = Vector3.zero;
                }
                else if (attackPause > 12.5)
                {
                    banjoSwipe.transform.position = new Vector3(0, 0);
                }
                else if (attackPause > 11.5)
                {
                    banjoSwipe.transform.position = new Vector3(0, 10);
                }
                else if (attackPause > 10)
                {
                    attackPause = 30;
                }
            }
        void CLAttacks()
        {
            if (attackPause > 44)
            {
                stanza1.transform.position += Vector3.left * Time.deltaTime * 4;
                stanza2.transform.position += Vector3.left * Time.deltaTime * 4;
            }
            else if (attackPause > 40)
            {
                note1.transform.eulerAngles += new Vector3(0, 0, -10) * Time.deltaTime;
                note1.transform.position += new Vector3(-0.1f, -1) * Time.deltaTime * 8;
                stanza1.transform.position += Vector3.left * Time.deltaTime * 4;
                stanza2.transform.position += Vector3.left * Time.deltaTime * 4;
            }
            else if (attackPause > 35)
            {
                note2.transform.eulerAngles += new Vector3(0, 0, 10) * Time.deltaTime;
                note2.transform.position += new Vector3(0.1f, -1) * Time.deltaTime * 8;
                stanza1.transform.position += Vector3.left * Time.deltaTime * 4;
                stanza2.transform.position += Vector3.left * Time.deltaTime * 4;
            }
            else if (attackPause > 30)
            {
                note3.transform.eulerAngles += new Vector3(0, 0, -10) * Time.deltaTime;
                note3.transform.position += new Vector3(-0.05f, -1) * Time.deltaTime * 8;
                stanza1.transform.position += Vector3.left * Time.deltaTime * 4;
                stanza2.transform.position += Vector3.left * Time.deltaTime * 4;
            }
            else if (attackPause > 26.6)
            {
                note1.transform.position = new Vector3(0, 10);
                note2.transform.position = new Vector3(0, 10);
                note3.transform.position = new Vector3(0, 10);
                note1.transform.eulerAngles = Vector3.zero;
                note2.transform.eulerAngles = Vector3.zero;
                note3.transform.eulerAngles = Vector3.zero;
                stanza1.transform.position += Vector3.left * Time.deltaTime * 4;
                stanza2.transform.position += Vector3.left * Time.deltaTime * 4;
                flute.transform.position += Vector3.down * Time.deltaTime * 7;
            }
            else if (attackPause > 12.2)
            {
                stanza1.transform.position += Vector3.left * Time.deltaTime * 4;
                stanza2.transform.position += Vector3.left * Time.deltaTime * 4;
                flute.transform.eulerAngles += new Vector3(0, 0, 15) * Time.deltaTime * 5;
            } else if (attackPause > 8)
            {
                stanza1.transform.position = new Vector3(20, -2);
                stanza2.transform.position = new Vector3(31.5f, -3);
                flute.transform.position += Vector3.down * Time.deltaTime * 7;
                paper1.transform.eulerAngles += new Vector3(0, 0, 50) * Time.deltaTime;
                paper1.transform.position += new Vector3(-1, -1) * Time.deltaTime * 7;
            }
            else if (attackPause > 4)
            {
                paper1.transform.eulerAngles += new Vector3(0, 0, -40) * Time.deltaTime;
                paper1.transform.position += new Vector3(-1.5f, -1) * Time.deltaTime * 5;
                paper2.transform.position += new Vector3(1, -1.5f) * Time.deltaTime * 5;
                paper2.transform.eulerAngles += new Vector3(0, 0, -40) * Time.deltaTime;
            }
            else if (attackPause > 1)
            {
                flute.transform.position = new Vector3(0.1f, 10);
                paper2.transform.position += new Vector3(1.5f, -1) * Time.deltaTime * 5;
                paper2.transform.eulerAngles += new Vector3(0, 0, 40) * Time.deltaTime;
            }
            else if (attackPause > 0)
            {
                paper1.transform.position = new Vector3(20, 15);
                paper2.transform.position = new Vector3(-16, 15);
                paper1.transform.eulerAngles = Vector3.zero;
                paper2.transform.eulerAngles = Vector3.zero;
                attackPause = 50;
            }
        }
        void FLAttacks()
        {
            if (attackPause > 46.001)
            {
                playerCamera.transform.eulerAngles += new Vector3(0, 0, 15) * Time.deltaTime * 6;
            } 
            else if (attackPause > 38)
            {
                fan.transform.position += Vector3.down * Time.deltaTime * 7;
                fan.transform.eulerAngles += new Vector3(0, 0, 80) * Time.deltaTime * 3;
            }
            else if (attackPause > 37.9f)
            {
                fan.transform.position = new Vector3(1, -10);
            }
            else if (attackPause > 32)
            {
                fan.transform.position += Vector3.up * Time.deltaTime * 7;
                fan.transform.eulerAngles += new Vector3(0, 0, 80) * Time.deltaTime * 4;
            }
            else if (attackPause > 27.999)
            {
                fan.SetActive(false);
                playerCamera.transform.eulerAngles += new Vector3(0, 0, 15) * Time.deltaTime * 6;
            }
            else if (attackPause > 25.5f)
            {
                fan.SetActive(true);
                fan.transform.position = new Vector3(-1, 20);
                fan.transform.eulerAngles = Vector3.zero;
            }
            else if (attackPause > 25)
            {
                playerCamera.transform.eulerAngles = new Vector3(0, 0, -40);
                fire1.transform.position += Vector3.left * Time.deltaTime * 9;
            }
            else if (attackPause > 23)
            {
                fire1.transform.position += Vector3.left * Time.deltaTime * 9;
            }
            else if (attackPause > 21.5f)
            {
                playerCamera.transform.eulerAngles += new Vector3(0, 0, 30) * Time.deltaTime;
                fire1.transform.position += Vector3.left * Time.deltaTime * 9;
            }
            else if (attackPause > 21)
            {
                playerCamera.transform.eulerAngles = new Vector3(0, 0, 40);
                fire1.transform.position += Vector3.left * Time.deltaTime * 9;
                fire2.transform.position += Vector3.right * Time.deltaTime * 9;
            }
            else if (attackPause > 18)
            {
                fire1.transform.position += Vector3.left * Time.deltaTime * 9;
                fire2.transform.position += Vector3.right * Time.deltaTime * 9;
            } 
            else if (attackPause > 15.325f)
            {
                playerCamera.transform.eulerAngles += new Vector3(0, 0, -30) * Time.deltaTime;
                fire1.transform.position += Vector3.left * Time.deltaTime * 9;
                fire2.transform.position += Vector3.right * Time.deltaTime * 9;
            } 
            else if (attackPause > 11)
            {
                fire2.transform.position += Vector3.right * Time.deltaTime * 9;
                petal1.transform.position = new Vector3(0, 3);
                petal2.transform.position = new Vector3(0, 3);
                petal3.transform.position = new Vector3(0, 3);
                petal4.transform.position = new Vector3(0, 3);
                petal1.SetActive(false);
                petal2.SetActive(false);
                petal3.SetActive(false);
                petal4.SetActive(false);
            }
            else if (attackPause > 4)
            {
                fire1.transform.position = new Vector3(20, -1);
                fire2.transform.position = new Vector3(-20, -3);
                petal1.SetActive(true);
                petal2.SetActive(true);
                petal3.SetActive(true);
                petal4.SetActive(true);
                petal1.transform.eulerAngles += new Vector3(0, 0, -20) * Time.deltaTime * 2;
                petal2.transform.eulerAngles += new Vector3(0, 0, 10) * Time.deltaTime * 2;
                petal3.transform.eulerAngles += new Vector3(0, 0, 20) * Time.deltaTime * 2;
                petal4.transform.eulerAngles += new Vector3(0, 0, -10) * Time.deltaTime * 2;
                petal1.transform.position += new Vector3(-0.1f, -1) * Time.deltaTime * 3;
                petal2.transform.position += new Vector3(-0.5f, -1.2f) * Time.deltaTime * 3;
                petal3.transform.position += new Vector3(0.3f, -0.8f) * Time.deltaTime * 3;
                petal4.transform.position += new Vector3(0.5f, -1.3f) * Time.deltaTime * 3;
            }
            else if (attackPause > 1)
            {
                petal1.transform.eulerAngles += new Vector3(0, 0, 10) * Time.deltaTime * 2;
                petal3.transform.eulerAngles += new Vector3(0, 0, -20) * Time.deltaTime * 2;
                petal1.transform.position += new Vector3(-0.1f, -1) * Time.deltaTime * 3;
                petal2.transform.position += new Vector3(-0.5f, -1.2f) * Time.deltaTime * 3;
                petal3.transform.position += new Vector3(0.3f, -0.8f) * Time.deltaTime * 3;
                petal4.transform.position += new Vector3(0.5f, -1.3f) * Time.deltaTime * 3;
            }
            else if (attackPause > 0)
            {
                petal1.transform.position = new Vector3(0, 15);
                petal2.transform.position = new Vector3(0, 15);
                petal3.transform.position = new Vector3(0, 15);
                petal4.transform.position = new Vector3(0, 15);
                petal1.transform.eulerAngles = Vector3.zero;
                petal2.transform.eulerAngles = Vector3.zero;
                petal3.transform.eulerAngles = Vector3.zero;
                petal4.transform.eulerAngles = Vector3.zero;
                attackPause = 50;
            }
        }
        if (attackPause > 0)
        {
            attackPause -= Time.deltaTime * 2;
        }
    }

    void OneRandom(float int1, float int2)
    {
        if (ifRand)
        {
            randInt = Random.Range(int1, int2);
            ifRand = false;
        }
    }

    void InstantiateEverything()
    {
        bullet1 = Instantiate(CObullet, new Vector3(-2, 11), Quaternion.identity);
        bullet2 = Instantiate(CObullet, new Vector3(0, 10), Quaternion.identity);
        bullet3 = Instantiate(CObullet, new Vector3(2, 11), Quaternion.identity);
        splitBullet1 = Instantiate(COsplitBullet1, new Vector3(0, 10), Quaternion.identity);
        splitBullet2 = Instantiate(COsplitBullet2, new Vector3(0, 10), Quaternion.identity);
        swipe = Instantiate(COslash, new Vector3(0, 10), Quaternion.identity);
        bomb = Instantiate(CObomb, new Vector3(-15, -2), Quaternion.identity);
        bomb2 = Instantiate(CObomb, new Vector3(15, -4), Quaternion.identity);
        blast = Instantiate(COboom, new Vector3(-15, -2), Quaternion.identity);
        blast2 = Instantiate(COboom, new Vector3(15, -4), Quaternion.identity);
        banjoSwipe = Instantiate(CObanjoswipe, new Vector3(0, 10), Quaternion.identity);
        bullet1.transform.parent = COcollection.transform;
        bullet2.transform.parent = COcollection.transform;
        bullet3.transform.parent = COcollection.transform;
        splitBullet1.transform.parent = COcollection.transform;
        splitBullet2.transform.parent = COcollection.transform;
        swipe.transform.parent = COcollection.transform;
        bomb.transform.parent = COcollection.transform;
        bomb2.transform.parent = COcollection.transform;
        blast.transform.parent = COcollection.transform;
        blast2.transform.parent = COcollection.transform;
        banjoSwipe.transform.parent = COcollection.transform;

        stanza1 = Instantiate(CLlines, new Vector3(20, -2), Quaternion.identity);
        stanza2 = Instantiate(CLlines, new Vector3(31.5f, -3), Quaternion.identity);
        note1 = Instantiate(CLnote1, new Vector3(0, 10), Quaternion.identity);
        note2 = Instantiate(CLnote2, new Vector3(0, 10), Quaternion.identity);
        note3 = Instantiate(CLnote3, new Vector3(0, 10), Quaternion.identity);
        flute = Instantiate(CLflute, new Vector3(0.1f, 10), Quaternion.identity);
        paper1 = Instantiate(CLpaper1, new Vector3(20, 15), Quaternion.identity);
        paper2 = Instantiate(CLpaper2, new Vector3(-16, 15), Quaternion.identity);
        stanza1.transform.parent = CLcollection.transform;
        stanza2.transform.parent = CLcollection.transform;
        note1.transform.parent = CLcollection.transform;
        note2.transform.parent = CLcollection.transform;
        note3.transform.parent = CLcollection.transform;
        flute.transform.parent = CLcollection.transform;
        paper1.transform.parent = CLcollection.transform;
        paper2.transform.parent = CLcollection.transform;

        fan = Instantiate(FLfan, new Vector3(-1, 20), Quaternion.identity);
        fire1 = Instantiate(FLfire, new Vector3(20, -1), Quaternion.identity);
        fire2 = Instantiate(FLfire, new Vector3(-20, -3), Quaternion.identity);
        petal1 = Instantiate(FLpetal1, new Vector3(0, 15), Quaternion.identity);
        petal2 = Instantiate(FLpetal1, new Vector3(0, 15), Quaternion.identity);
        petal3 = Instantiate(FLpetal2, new Vector3(0, 15), Quaternion.identity);
        petal4 = Instantiate(FLpetal2, new Vector3(0, 15), Quaternion.identity);
        fan.transform.parent = FLcollection.transform;
        fire1.transform.parent = FLcollection.transform;
        fire2.transform.parent = FLcollection.transform;
        petal1.transform.parent = FLcollection.transform;
        petal2.transform.parent = FLcollection.transform;
        petal3.transform.parent = FLcollection.transform;
        petal4.transform.parent = FLcollection.transform;
    }
}
