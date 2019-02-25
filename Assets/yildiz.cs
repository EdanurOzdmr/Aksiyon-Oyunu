using UnityEngine;
using System.Collections;

public class yildiz : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "karakter")
        {
            
            Karakter.yildiz_sayisi++;
            Debug.Log(Karakter.yildiz_sayisi);
            GameObject.Destroy(this.gameObject);
        }
    }
    }
