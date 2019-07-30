using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public bool loose = false;
    public MoveFing PlayR;
    public bool drawlink = false;
    public GameObject linepref;
    public GameObject currentstar=null;
    public int starscoll=0;
    public Text score;
    public LevelProp levprop;
    void Start()
    {
        score.text = starscoll.ToString() + "/" + levprop.maxstars.ToString();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collide with: "+other.gameObject.tag);
        if (currentstar!= other.gameObject)
        if (other.gameObject.tag == "Star") {
                if (other.gameObject.GetComponent<Star>().havelink == false)
                {
                    starscoll += 1;
                    score.text =starscoll.ToString()+"/"+levprop.maxstars.ToString();
                    other.gameObject.GetComponent<Star>().havelink = true;
                    currentstar = other.gameObject;
                    if (!drawlink) { PlayR.currlink = Instantiate(linepref); PlayR.currlink.GetComponent<Crosslink>().starSt = other.gameObject; }
                    else {
                        PlayR.currlink.GetComponent<Crosslink>().starFn = other.gameObject;
                        PlayR.LineDraw(PlayR.currlink, PlayR.startlink, other.gameObject.transform.position, false);
                        PlayR.currlink.GetComponent<BoxCollider2D>().enabled = true;
                        PlayR.currlink = Instantiate(linepref);
                        PlayR.currlink.GetComponent<Crosslink>().starSt = other.gameObject;
                    }
                    PlayR.currlink.GetComponent<Crosslink>().lvlp = levprop;
                    PlayR.startlink = other.gameObject.transform.position;
                    drawlink = true;
                    if (starscoll== levprop.maxstars) {
                        levprop.scch = true;
                       // levprop.NextS();
                    }
                }
        }
//        if (other.gameObject.tag == "Link") {
 //           loose = true;
        //    drawlink = false;
   //     }
    }


}
