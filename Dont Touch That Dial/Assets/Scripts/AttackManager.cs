using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public GameObject COsprite;
    public GameObject CLsprite;
    public GameObject FLsprite;

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
        if (COsprite.activeSelf)
        {
            if (COInit)
            {
                COcollection.SetActive(true);
                FLcollection.SetActive(false);
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
                swipe.gameObject.transform.position = new Vector3(0, 10);
            }
            else if (attackPause > 20)
            {
                ifRand = true;
                splitBullet1.transform.position -= new Vector3(-0.5f, -1) * Time.deltaTime * 7;
                splitBullet2.transform.position -= new Vector3(0.5f, 1) * Time.deltaTime * 7;
                bomb.transform.position += Vector3.right * Time.deltaTime * 8;
            }
            else if (attackPause > 19.5)
            {
                bullet1.gameObject.transform.position = new Vector3(-2, 11);
                bullet3.gameObject.transform.position = new Vector3(2, 11);
                blast.transform.position = bomb.transform.position;
                bomb.SetActive(false);   
            } else if (attackPause > 15.5)
            {
                bomb.SetActive(true);
                bomb.transform.position = new Vector3(-15, -2);
                blast.transform.position = new Vector3(-15, -2);
                bomb2.transform.position += Vector3.left * Time.deltaTime * 8;
            } else if (attackPause > 15)
            {
                blast2.transform.position = bomb2.transform.position;
                bomb2.SetActive(false);
            } else if (attackPause > 13.5)
            {
                bomb2.SetActive(true);
                bomb2.transform.position = new Vector3(15, -4);
                blast2.transform.position = new Vector3(15, -4);
            } else if (attackPause > 12.5)
            {
                banjoSwipe.transform.position = new Vector3(0, 0);
            } else if (attackPause > 11.5)
            {
                banjoSwipe.transform.position = new Vector3(0, 10);
            } else if (attackPause > 10)
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
                note1.transform.position += new Vector3(-0.1f, -1) * Time.deltaTime * 8;
                stanza1.transform.position += Vector3.left * Time.deltaTime * 4;
                stanza2.transform.position += Vector3.left * Time.deltaTime * 4;
            }
            else if (attackPause > 35)
            {
                note2.transform.position += new Vector3(0.1f, -1) * Time.deltaTime * 8;
                stanza1.transform.position += Vector3.left * Time.deltaTime * 4;
                stanza2.transform.position += Vector3.left * Time.deltaTime * 4;
            }
            else if (attackPause > 30)
            {
                note3.transform.position += new Vector3(-0.05f, -1) * Time.deltaTime * 8;
                stanza1.transform.position += Vector3.left * Time.deltaTime * 4;
                stanza2.transform.position += Vector3.left * Time.deltaTime * 4;
            }
            else if (attackPause > 26.6)
            {
                note1.transform.position = new Vector3(0, 10);
                note2.transform.position = new Vector3(0, 10);
                note3.transform.position = new Vector3(0, 10);
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
                paper1.transform.position += new Vector3(-1, -1) * Time.deltaTime * 7;
            }
            else if (attackPause > 4)
            {
                paper1.transform.position += new Vector3(-1.5f, -1) * Time.deltaTime * 5;
                paper2.transform.position += new Vector3(1, -1.5f) * Time.deltaTime * 5;
            }
            else if (attackPause > 1)
            {
                flute.transform.position = new Vector3(0.1f, 10);
                paper2.transform.position += new Vector3(1.5f, -1) * Time.deltaTime * 5;
            }
            else if (attackPause > 0)
            {
                paper1.transform.position = new Vector3(20, 15);
                paper2.transform.position = new Vector3(-16, 15);
                attackPause = 50;
            }
        }
        void FLAttacks()
        {

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

        stanza1 = Instantiate(CLlines, new Vector3(20, -2), Quaternion.identity);
        stanza2 = Instantiate(CLlines, new Vector3(31.5f, -3), Quaternion.identity);
        note1 = Instantiate(CLnote1, new Vector3(0, 10), Quaternion.identity);
        note2 = Instantiate(CLnote2, new Vector3(0, 10), Quaternion.identity);
        note3 = Instantiate(CLnote3, new Vector3(0, 10), Quaternion.identity);
        flute = Instantiate(CLflute, new Vector3(0.1f, 10), Quaternion.identity);
        paper1 = Instantiate(CLpaper1, new Vector3(20, 15), Quaternion.identity);
        paper2 = Instantiate(CLpaper2, new Vector3(-16, 15), Quaternion.identity);
    }
}
