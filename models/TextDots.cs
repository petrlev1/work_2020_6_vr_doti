using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDots : MonoBehaviour
{
	
	//private GameObject Play1;
	//private GameObject Aim;
	public GameObject TestText1;
	public GameObject TestText2;
	public GameObject Player;
	public GameObject aim;
	private GameObject PricelCanv;
	public GameObject Dot;
	public GameObject Text;
	public GameObject Text2;
	public GameObject ImgCanv;
	public GameObject ImgCanv1;
	public GameObject ImgCanv2;
	public GameObject ImgCanv3;
	public GameObject ImgCanv4;
	public GameObject ImgCanv5;
	public GameObject TextDotRight;
	public int ScreenPosY;
	public GameObject TestObj;
	//private GameObject Canvas;
	private GameObject Text1;
	
	//public Transform target;
    private GameObject MCam;
	private float Distance1;
	private float Distance2;
	
	
	
	/* public void OnDrawGizmos()
    {
		
		//ЛУЧ
	//сюда запишется инфо о пересечении луча, если оно будет
    RaycastHit hit;
    //сам луч, начинается от позиции этого объекта и направлен в сторону цели
    Ray ray = new Ray(Player.transform.position, aim.transform.position - Player.transform.position);
    //пускаем луч
    Physics.Raycast(ray, out hit);
	
        var DotCollider = Dot.GetComponent<Collider>();
		//Vector3 AimScreenPos = MCam.GetComponent<Camera>().WorldToScreenPoint(aim.transform.position);
		//Vector3 AimScreenPos = MCam.GetComponent<Camera>().WorldToScreenPoint(aim.transform.position);

        if (!DotCollider)
        {
            return; // nothing to do without a collider
        }

        Vector3 DotClosestPoint2 = DotCollider.ClosestPoint(hit.point);
		
		//Debug.Log( closestPoint );

        //Gizmos.DrawSphere(Player.transform.position, 0.1f);
        Gizmos.DrawWireSphere(DotClosestPoint2, 0.05f);
    } */ 
	
	
	
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
		
		//Play1 = GameObject.Find("Play1" );
		//Dot1 = GameObject.Find("Dot1" );
		//MCam = GameObject.Find("MCam" ); //Для Play1
	    MCam = GameObject.Find("CenterEyeAnchor" ); //Для VR
		//Aim = GameObject.Find("aim" );
		PricelCanv = GameObject.Find("pricel2" );
		Text1 = GameObject.Find("Text1" );
		
		
		
		
		
        
    }

   
  
	
	
	
    void Update()
    {
		
		//ЛУЧ
	//сюда запишется инфо о пересечении луча, если оно будет
    RaycastHit hit;
    //сам луч, начинается от позиции этого объекта и направлен в сторону цели
    Ray ray = new Ray(Player.transform.position, aim.transform.position - Player.transform.position);
    //пускаем луч
    Physics.Raycast(ray, out hit);
		
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
		Vector3 AimScreenPos = MCam.GetComponent<Camera>().WorldToScreenPoint(aim.transform.position);
		
		
		var DotCollider = Dot.GetComponent<Collider>();
		
		if (!DotCollider)
        {
            return; // nothing to do without a collider
        } 

//Ближайшая точка к прицелу на коллайдере дота
        Vector3 DotClosestPoint = DotCollider.ClosestPoint(hit.point);
		Vector3 DotClosestPointScreenPos = MCam.GetComponent<Camera>().WorldToScreenPoint(DotClosestPoint);
		
		//Debug.Log( "Ближ точка: " + DotClosestPoint );
		//Debug.Log( "Прицел: " + aim.transform.position.x );
		//Debug.Log( "Дистанц: " + Vector3.Distance( MCam.GetComponent<Camera>().WorldToScreenPoint(DotClosestPoint), MCam.GetComponent<Camera>().WorldToScreenPoint(aim.transform.position) ) );
		//Text1.GetComponent<Text>().text = DotScreenPos.ToString();
		
		//Позиционирование объекта
		//this.transform.position  = new Vector3( Screen.width / 5f + DotScreenPos.x / 1.1f, Screen.height / 2, 0.0f ); //Canvas Overlay
		/* if ( Mathf.RoundToInt(DotScreenPos.x) > 750 && Mathf.RoundToInt(DotScreenPos.x) < 845 ) {
			
			this.transform.localPosition  = new Vector3( Mathf.RoundToInt(785) - 450, Mathf.RoundToInt(869) - ScreenPosY, 0 );
			
		} else {
			
			this.transform.localPosition  = new Vector3( Mathf.RoundToInt(DotScreenPos.x) - 450, Mathf.RoundToInt(869) - ScreenPosY, 0 ); //Canvas Camera	
		
		} */
		
		this.transform.localPosition  = new Vector3( Mathf.RoundToInt(DotScreenPos.x) - 450, Mathf.RoundToInt(DotScreenPos.y) - ScreenPosY, 0 ); //Canvas Camera
		
		
		//TestText1.GetComponent<Text>().text = Mathf.RoundToInt(DotScreenPos.x).ToString();
//TestText2.GetComponent<Text>().text = Mathf.RoundToInt(DotScreenPos.y).ToString();

		Debug.Log( "DotScreenPos.x: " + Mathf.RoundToInt(DotScreenPos.x) );
		Debug.Log( "DotScreenPos.y: " + Mathf.RoundToInt(DotScreenPos.y) );
		
		//Исчезновение текста по мере отдаления
		//Distance1 = Vector3.Distance(Aim.transform.position, Dot.transform.position); //Дистанция между 3д объектами
		Distance2 = Vector3.Distance( DotScreenPos, AimScreenPos ); //Дистанция между объектами на канвасе
		//Distance2 = Vector3.Distance( DotScreenPos, DotClosestPointScreenPos );
		
		//if ( hit.collider == null && Distance2 > 150 ){
	
	
	Text.GetComponent<Text>().color = new UnityEngine.Color(1f, 1f, 1f, 1f - ( Distance2 / 100f ) );
		Text2.GetComponent<Text>().color = new UnityEngine.Color(1f, 1f, 1f, 1f - ( Distance2 / 100f ) );
		ImgCanv.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.3f / ( Distance2 / 100f ) );
		ImgCanv1.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.3f / ( Distance2 / 100f ) );
		ImgCanv2.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.3f / ( Distance2 / 100f ) );
		ImgCanv3.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.3f / ( Distance2 / 100f ) );
		ImgCanv4.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.3f / ( Distance2 / 100f ) );
		ImgCanv5.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 0.3f / ( Distance2 / 100f ) );
	
	if ( hit.collider == null ){
		
	if ( Vector3.Distance( DotScreenPos, AimScreenPos ) > 250 ) {
		
	gameObject.SetActive(false);
	
	}
	
	}
	
	if ( hit.collider != null ){
		
	Text.GetComponent<Text>().color = new UnityEngine.Color(1f, 1f, 1f, 1f );
		Text2.GetComponent<Text>().color = new UnityEngine.Color(1f, 1f, 1f, 1f );
		ImgCanv.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 1f );
		ImgCanv1.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 1f );
		ImgCanv2.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 1f );
		ImgCanv3.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 1f );
		ImgCanv4.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 1f );
		ImgCanv5.GetComponent<Image>().color = new UnityEngine.Color(1f, 1f, 1f, 1f );
		
		//this.transform.localPosition  = new Vector3( 355, 370, 0 );
	
	}
	
		
		 
		
	//}
	
	
	
	/* 
	
	if ( hit.collider != null ){
		
		
		
		
	} */
	
	
		
        
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
