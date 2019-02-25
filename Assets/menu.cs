using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

	public void bolum_ac(int bolum_sistemi)
	{
		Application.LoadLevel (bolum_sistemi);
	}
	public void Quıt()
	{
		Application.Quit ();	
	}
}
