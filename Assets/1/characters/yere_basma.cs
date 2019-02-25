using UnityEngine;
using System.Collections;

public class yere_basma : MonoBehaviour {
    Karakter k;
	// Use this for initialization
	void Start () {
       
        k = transform.root.GetComponent<Karakter>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "zemin")
        {
            k.yerdemi = true;
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "zemin")
        { 
        k.yerdemi=true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "zemin")
        {
            k.yerdemi = false;
        }
    }
}
