using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bolum_sistemi : MonoBehaviour {

	// Use this for initialization
	void Start () {
        kilit_sistemi();
	}
    public Button[] buttonlar;
	public void bolum_ac(string bolum_ismi)
    {
        Application.LoadLevel(bolum_ismi);
    }
    public void kilit_sistemi()
    {
        int bolums = PlayerPrefs.GetInt("bolum");
        for(int i=0; i<buttonlar.Length; i++)
        {
            if(bolums+ 1>=int.Parse(buttonlar[i].name))
            {
                buttonlar[i].interactable = true;
            }
            else
            {
                buttonlar[i].interactable = false;
            }
        }
    }
}
