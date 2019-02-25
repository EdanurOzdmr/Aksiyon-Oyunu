using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Karakter : MonoBehaviour {

    // Use this for initialization
    public float hiz;
    public float h;
    public float ziplama_gucu;
    Rigidbody2D fizik_karakter;
    Animator animasyon_oynatici;
    public bool yerdemi,ciftZipla;
    public static int yildiz_sayisi;
    public Text textimiz;
    public int can_sayisi;
    float time = 0f;
    public GameObject [] canlar;
    public int max_Can;

	void Start () {
        yildiz_sayisi = 0;
        if (PlayerPrefs.HasKey("yildiz"))
        {
            yildiz_sayisi = PlayerPrefs.GetInt("yildiz");
        }               
        fizik_karakter = GetComponent<Rigidbody2D>();
        animasyon_oynatici = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        textimiz.text = yildiz_sayisi.ToString();
        if (can_sayisi == 0)
        {
            ol();
        }
        if (Input.GetKeyDown(KeyCode.Space) )
        {
			if (yerdemi) 
			{
				fizik_karakter.velocity += new Vector2 (0, ziplama_gucu);
				yerdemi = false;
				ciftZipla = true;
			} 
			else 
			{
				if (ciftZipla)
				{
					ciftZipla = false;
					fizik_karakter.velocity += new Vector2 (0, ziplama_gucu/4);
				}

			}

        }
       
        if (transform.position.y < -8f)
        {
            ol();
            
        }
	
	}
    void FixedUpdate()//Hareket komutları burada oluşturulur. Hızlı olduğu için.
    {
         h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h * hiz * Time.deltaTime, 0, 0);
        if (h > 0) {
            transform.rotation = new Quaternion(0, 0, 0, 0);
                }
        else if (h < 0)
        {
            
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        animasyon_oynatici.SetFloat("hız", Mathf.Abs(h));
        animasyon_oynatici.SetBool("yerde", yerdemi);
    }

    void ol()
    {
        PlayerPrefs.SetInt("yildiz", yildiz_sayisi);
        Application.LoadLevel(Application.loadedLevel);
    }

    void Can_azalma()
    {
        can_sayisi--;
        GameObject.Find("can" + can_sayisi.ToString()).active=false;
    }

     void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "buz")
        {

            if (time <= 0)
            { 

            Can_azalma();
                time = 3f;

            }
        }
        else if(coll.gameObject.tag == "can")
        {
            if (can_sayisi < max_Can)
            {
                canlar[can_sayisi].active = true;
                can_sayisi++;
                GameObject.Destroy(coll.gameObject);

            }

        }
        else if (coll.gameObject.tag=="door")
        { 
			
            PlayerPrefs.SetInt("yildiz", yildiz_sayisi);
            PlayerPrefs.SetInt("bolum", Application.loadedLevel);
            Application.LoadLevel("2");

        }
    }

     void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "buz")
        {

            if (time <= 0)
            {

                Can_azalma();
                time = 2f;

            }
        }

    }
   
}
