using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global
{
	
	public static GameObject mDot1;
	public static GameObject mDot2;
	public static GameObject mDot3;
	public static GameObject mDot4;
	public static GameObject mDot5;
	
	public static GameObject TextDot1;
	public static GameObject TextDot2;
	public static GameObject TextDot3;
	public static GameObject TextDot4;
	public static GameObject TextDot5;
	
	public static float Time1 = 0.0f;
	public static int Time2 = 0;
	
}

public class Globals : MonoBehaviour
{
	
	
	void Awake()
    {

Global.mDot1 = GameObject.Find("mDot1");
Global.mDot2 = GameObject.Find("mDot2");
Global.mDot3 = GameObject.Find("mDot3");
Global.mDot4 = GameObject.Find("mDot4");
Global.mDot5 = GameObject.Find("mDot5");

Global.mDot1.SetActive(false);
Global.mDot2.SetActive(false);
Global.mDot3.SetActive(false);
Global.mDot4.SetActive(false);
Global.mDot5.SetActive(false);

Global.TextDot1 = GameObject.Find("TextDot1");
		 Global.TextDot2 = GameObject.Find("TextDot2");
		Global.TextDot3 = GameObject.Find("TextDot3");
		Global.TextDot4 = GameObject.Find("TextDot4");
		Global.TextDot5 = GameObject.Find("TextDot5");
	
    }
	
	void Start()
	{
		
		
		
	}
	
	 void Update()
    {
	
	Global.Time2 = Mathf.RoundToInt( Global.Time1 += Time.deltaTime );
	
	}

   
   
}
