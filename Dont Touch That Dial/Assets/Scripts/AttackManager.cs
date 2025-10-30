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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            
            GameObject bullet1 = Instantiate(CObullet, new Vector3(-2, 10), Quaternion.identity);
            GameObject bullet2 = Instantiate(CObullet, new Vector3(0, 10), Quaternion.identity);
            GameObject bullet3 = Instantiate(CObullet, new Vector3(2, 10), Quaternion.identity);
            bullet1.transform.position -= Vector3.down * Time.deltaTime;
            bullet2.transform.position -= Vector3.down * Time.deltaTime;
            bullet3.transform.position -= Vector3.down * Time.deltaTime;
        }
        void CLAttacks()
        {

        }
        void FLAttacks()
        {

        }
    }
}
