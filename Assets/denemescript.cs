using UnityEngine;
using System.Collections;

public class denemescript : MonoBehaviour {

    public GameObject Camera;
    Transform pozisyon;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, transform.position.z);
    }
}
