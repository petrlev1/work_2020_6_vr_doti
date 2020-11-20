using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDots : MonoBehaviour
{
	
	private GameObject Play1;
	//private GameObject Aim;
	private GameObject PricelCanv;
	public GameObject Dot;
	public GameObject Text;
	public GameObject Text2;
	public GameObject ImgCanv;
	public GameObject ImgCanv1;
	public GameObject ImgCanv2;
	public GameObject ImgCanv3;
	public GameObject ImgCanv4;
	public GameObject TextDotRight;
	//private GameObject Canvas;
	private GameObject Text1;
	
	//public Transform target;
    private GameObject MCam;
	private float Distance1;
	private float Distance2;
	
	
	
	void OnEnable()
	{
		//TextDotRight.SetActive(false);
		StartCoroutine(TextDotRightWait());
	}
	
	
	void Awake()
    {
		
		//gameObject.SetActive(false);
		//TextDotRight = GameObject.Find("TextDotRight");
		//TextDotRight.SetActive(false);
		//TextDotRight.SetActive(true);
		
	}
	
	
	
    // Start is called before the first frame update
    void Start()
    {
		
		Play1 = GameObject.Find("Play1" );
		//Dot1 = GameObject.Find("Dot1" );
		//MCam = GameObject.Find("MCam" ); //Для Play1
	    MCam = GameObject.Find("CenterEyeAnchor" ); //Для VR
		//Aim = GameObject.Find("aim" );
		PricelCanv = GameObject.Find("pricel2" );
		Text1 = GameObject.Find("Text1" );
		
		
		
		
		
        
    }

   
  
	
	
	
    void Update()
    {
		
		//Debug.Log ( "Play1: " + Play1.transform.rotation.y );
		//Debug.Log ( "Dot1: " + Dot.transform.position );
		//Debug.Log ( "this: " + this.transform.position );
		//Debug.Log ( "thisLoc: " + this.transform.localPosition );
		//Debug.Log ( "this: " + this.transform.rotation.y );
		//Debug.Log ( "new: " + this.transform.localRotation.y );
		
		
        //Debug.Log("Dot1 screenPos.x:" + DotScreenPos.x + " y:" + DotScreenPos.y );
		//Debug.Log("AimScreenPos.x:" + AimScreenPos.x + " y:" + AimScreenPos.y );
		//Debug.Log( "Dist: " + Vector3.Distance(DotScreenPos, AimScreenPos) );
		
		//Debug.Log("PricelCanv: " + PricelCanv.transform.position );
		
		
		
		//this.transform.rotation = new Vector3(0.75f, 0.0f, 0.0f);
		//this.transform.Rotate(0.0f, Play1.transform.rotation.y, 0.0f, Space.Self);
		
		//Выравнивание относительно камеры для 3D
		//this.transform.localRotation = Quaternion.Euler( 1, Play1.transform.rotation.y * 135 ,1 );
		
		
		//Высчитываем позиция 3d объекта относительно экрана
		Vector3 DotScreenPos = MCam.GetComponent<Camera>().WorldToScreenPoint(Dot.transform.position);
		Vector3 AimScreenPos = MCam.GetComponent<Camera>().WorldToScreenPoint(PricelCanv.transform.position);
		
		//Debug.Log( DotScreenPos );
		//Text1.GetComponent<Text>().text = DotScreenPos.ToString();
		
		//Позиционирование объекта
		//this.transform.position  = new Vector3( Screen.width / 5f + DotScreenPos.x / 1.1f, Screen.height / 2, 0.0f ); //Canvas Overlay
		this.transform.localPosition  = new Vector3( Mathf.RoundToInt(DotScreenPos.x) - 450, Mathf.RoundToInt(DotScreenPos.y) - 500, 0 ); //Canvas Camera
		
		//Исчезновение текста по мере отдаления
		//Distance1 = Vector3.Distance(Aim.transform.position, Dot.transform.position); //Дистанция между 3д объектами
		Distance2 = Vector3.Distance( DotScreenPos, AimScreenPos ); //Дистанция между объектами на канвасе
		Text.GetComponent<Text>().color = new UnityEngine.Color(1f, 1f, 1f, 1f - ( Distance2 / 100f ) );
		Text2.GetComponent<Text>().color = new UnityEngine.Color(1f, 1f, 1f, 1f - ( Distance2 / 100f ) );
		ImgCanv.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.1f / ( Distance2 / 100f ) );
		ImgCanv1.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.1f / ( Distance2 / 100f ) );
		ImgCanv2.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.1f / ( Distance2 / 100f ) );
		ImgCanv3.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.1f / ( Distance2 / 100f ) );
		
		
		
		//Дистанция полного исчезновения объекта
	if ( Distance2 > 150 ) {
	
	gameObject.SetActive(false);
	
	}
	
	
        
    }
	
	
	void OnDisable() 
	{
		TextDotRight.SetActive(false);
		//TextDotRight = GameObject.Find("TextDot1");
	}
	
	
	
	IEnumerator TextDotRightWait()
    {
		yield return new WaitForSeconds(2.0f);
		TextDotRight.SetActive(true);
	}
		
}
