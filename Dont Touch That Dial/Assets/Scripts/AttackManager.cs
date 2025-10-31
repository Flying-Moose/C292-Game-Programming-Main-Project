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
    private bool temp;
    private bool temp2;
    private bool instantiated;

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
                bullet1.transform.position += Vector3.down * Time.deltaTime * 7;
                bullet2.transform.position += Vector3.down * Time.deltaTime * 7;
                bullet3.transform.position += Vector3.down * Time.deltaTime * 7;
                attackPause -= Time.deltaTime;
            }
            else if (attackPause > 25.9)
            {
                bullet2.gameObject.transform.position = new Vector3(0, 10);
                bullet1.transform.position += Vector3.down * Time.deltaTime * 7;
                bullet3.transform.position += Vector3.down * Time.deltaTime * 7;
                swipe.gameObject.transform.position = new Vector3(0, -2);
                splitBullet1.gameObject.transform.position = new Vector3(0, -3);
                splitBullet2.gameObject.transform.position = new Vector3(0, -3);
                attackPause -= Time.deltaTime;
            }
            else if (attackPause > 22)
            {
                bullet1.transform.position += Vector3.down * Time.deltaTime * 7;
                bullet3.transform.position += Vector3.down * Time.deltaTime * 7;
                splitBullet1.transform.position -= new Vector3(-1,-1) * Time.deltaTime * 7;
                splitBullet2.transform.position -= new Vector3(1, 1) * Time.deltaTime * 7;
                swipe.gameObject.transform.position = new Vector3(0, 10);
                attackPause -= Time.deltaTime;
            }
            else if (attackPause > 18)
            {
                bomb.transform.position += Vector3.right * Time.deltaTime * 8;
                bullet1.gameObject.transform.position = new Vector3(-2, 11);
                bullet3.gameObject.transform.position = new Vector3(2, 11);
                attackPause -= Time.deltaTime;
            }
            else if (attackPause > 17.5)
            {
                blast.transform.position = bomb.transform.position;
                bomb.SetActive(false);   
                attackPause -= Time.deltaTime;
            } else if (attackPause > 16)
            {
                blast.transform.position = new Vector3(-15, 2);
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
            attackPause -= Time.deltaTime;
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
        bomb2 = Instantiate(CObomb, new Vector3(15, -2), Quaternion.identity);
        blast = Instantiate(COboom, new Vector3(-15, -2), Quaternion.identity);
        blast2 = Instantiate(COboom, new Vector3(15, -2), Quaternion.identity);
    }
}
