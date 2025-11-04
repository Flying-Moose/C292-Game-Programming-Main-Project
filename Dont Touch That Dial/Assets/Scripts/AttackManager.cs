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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InstantiateEverything();
        attackPause = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (COsprite.activeSelf)
        {
            COAttacks();
        } 
        else if (CLsprite.activeSelf)
        {
            CLAttacks();
        } 
        else if (FLsprite.activeSelf)
        {
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
    }
}
