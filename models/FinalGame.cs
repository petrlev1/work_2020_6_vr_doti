using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalGame : MonoBehaviour
{
    

public GameObject aim;

	private GameObject Dot1;
	private GameObject Dot2;
	private GameObject Dot3;
	private GameObject Dot4;
	private GameObject Dot5;
	
	private GameObject[] mDots;
	
	private GameObject Vzriv1;
	private GameObject Vzriv2;
	private GameObject Vzriv3;
	private GameObject Vzriv4;
	private GameObject Vzriv5;
	
	public GameObject Text1;
	private GameObject NoteFire;
	private GameObject ButFire;
	
	private Rigidbody _rb;
	
	private GameObject Camera11;
	public float WaitTime;
	
	/* float Time1 = 0.0f;
	int Time2 = 0; */
	


	
	void Awake()
    {
		
		//Camera11 = GameObject.Find("CenterEyeAnchor" ) // для VR;
		//Camera11 = this.gameObject; // для Play;
		
		Vzriv1 = GameObject.Find("Vzriv1" );
Vzriv2 = GameObject.Find("Vzriv2" );
Vzriv3 = GameObject.Find("Vzriv3" );
Vzriv4 = GameObject.Find("Vzriv4" );
Vzriv5 = GameObject.Find("Vzriv5" );

		NoteFire = GameObject.Find("NoteFire");
		ButFire = GameObject.Find("ButFire");
		
	}
	
    void Start()
    {
		
	
//Записываем переменную 1й позиции	
	//PlayerPrefs.SetFloat( "Pos1", Camera11.transform.rotation.y );	

		
Dot1 = GameObject.Find("Dot1" );
Dot2 = GameObject.Find("Dot2" );
Dot3 = GameObject.Find("Dot3" );
Dot4 = GameObject.Find("Dot4" );
Dot5 = GameObject.Find("Dot5" );

NoteFire.SetActive(false);

Vzriv1.SetActive(false);
Vzriv2.SetActive(false);
Vzriv3.SetActive(false);
Vzriv4.SetActive(false);
Vzriv5.SetActive(false);

_rb = GetComponent<Rigidbody>();


        
    }

    
    void Update()
    {
		
		//Debug.Log ( "rot: " + this.transform.rotation.y );
		//Debug.Log ( "rot2: " + Mathf.RoundToInt(this.transform.rotation.y) );
		//Debug.Log ( "per: " + PlayerPrefs.GetFloat("Pos1"));
		//Debug.Log ( "sum: " + (this.transform.rotation.x + PlayerPrefs.GetFloat("Pos1")) );
		//Debug.Log ( "Dist: " + Vector3.Distance( PlayerPrefs.GetFloat("Pos1"), this.transform.rotation.x ) );
		
		//StartCoroutine( Pos1());
	
		
		//int Time1 = Mathf.RoundToInt(Time.time);
		//float Time1 += Time.deltaTime;
		
		 
		 //Time2 = Mathf.RoundToInt(Time1 += Time.deltaTime);
		
		//Debug.Log ( Global.Time2 );
		
		/* if ( Global.Time2 == 2 ) {
			
			Debug.Log ( "cool" );
			
			} */
			
			/* Time1 = 0;
			
			if ( Camera11.transform.rotation.y == PlayerPrefs.GetFloat("Pos1") ) {
				
				Text1.GetComponent<Text>().text = "Переменные равны";
				Debug.Log ( "Переменные равны" );
				Debug.Log ( "Camera11.transform.rotation.y: " + Camera11.transform.rotation.y );
				Debug.Log ( "PlayerPrefs.GetFloat(Pos1): " + PlayerPrefs.GetFloat("Pos1") );
				
			} else {
				Text1.GetComponent<Text>().text = "Переменные НЕ равны";
				Debug.Log ( "Переменные НЕ равны" );
				Debug.Log ( "Camera11.transform.rotation.y: " + Camera11.transform.rotation.y );
				Debug.Log ( "PlayerPrefs.GetFloat(Pos1): " + PlayerPrefs.GetFloat("Pos1") );
			}
			PlayerPrefs.SetFloat( "Pos1", Camera11.transform.rotation.y ); */
			//Debug.Log ( "per: " + PlayerPrefs.GetFloat("Pos1"));
			
		
		
		
		
		
		
		//mDot1.SetActive(false);

		
		//mDots = GameObject.FindGameObjectsWithTag("mDots");
		/* foreach (GameObject dotAll in mDots){
                       dotAll.SetActive(false);
                 }  */
		
		
		//ЛУЧ
	//сюда запишется инфо о пересечении луча, если оно будет
    RaycastHit hit;
    //сам луч, начинается от позиции этого объекта и направлен в сторону цели
    Ray ray = new Ray(transform.position, aim.transform.position - transform.position);
    //пускаем луч
    Physics.Raycast(ray, out hit);
	
	//просто для наглядности рисуем луч в окне Scene
	//Debug.DrawLine(ray.origin, hit.point,Color.red);
	
	
	
	
	
	
	
		
		//Проверяем открытие всех дотов
		if ( Dot1.GetComponent<Dots>().bool1 == true & Dot2.GetComponent<Dots>().bool1 == true & Dot3.GetComponent<Dots>().bool1 == true & Dot4.GetComponent<Dots>().bool1 == true & Dot5.GetComponent<Dots>().bool1 == true ) {
			
			//Debug.Log ("bool");
			NoteFire.SetActive(true);
			
        }
		
		
		//Жмем на кнопку ОГОНЬ
		if ( hit.collider != null ){
	
	if ( hit.collider.gameObject == ButFire.gameObject ){
		
		//Debug.Log ("fire");
		Dot1.GetComponent<Dots>().bool1 = false;
		NoteFire.SetActive(false);
		
Dot1.SetActive(false);
Dot2.SetActive(false);
Dot3.SetActive(false);
Dot4.SetActive(false);
Dot5.SetActive(false);
		
		Global.mDot1.SetActive(false); 
		Global.mDot2.SetActive(false); 
		Global.mDot3.SetActive(false);
		Global.mDot4.SetActive(false);
		Global.mDot5.SetActive(false);
		
		Global.TextDot1.SetActive(false);
Global.TextDot2.SetActive(false);
Global.TextDot3.SetActive(false);
Global.TextDot4.SetActive(false);
Global.TextDot5.SetActive(false);
		
		StartCoroutine( Vzriv() );
		
		StartCoroutine( Wait1());
		

		
		//Debug.Log ("test");
		
	} else {
		
		//TextDot1.SetActive(false);
	}
	
	}
		
		
	
	

   if ( (Input.anyKeyDown ) ) { // реагирует на любое действие пользователя - мышь, клава, тачскри
		   
	   Text1.GetComponent<Text>().text = "COOl";
	   //Debug.Log ( " Cool " );
	   
    }
	
	 
	 //Debug.Log ( transform.rotation );

	
	}

	
	
	
	IEnumerator Wait1()
    {
       
yield return new WaitForSeconds( WaitTime );

Dot1.SetActive(true);
Dot2.SetActive(true);
Dot3.SetActive(true);
Dot4.SetActive(true);
Dot5.SetActive(true);

Dot1.GetComponent<Dots>().bool1 = false;
Dot2.GetComponent<Dots>().bool1 = false;
Dot3.GetComponent<Dots>().bool1 = false;
Dot4.GetComponent<Dots>().bool1 = false;
Dot5.GetComponent<Dots>().bool1 = false;

Global.mDot1.SetActive(true);
Global.mDot2.SetActive(true);
Global.mDot3.SetActive(true);
Global.mDot4.SetActive(true);
Global.mDot5.SetActive(true);

Global.mDot1.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(1, 1, 1, 1);
Global.mDot1.gameObject.GetComponent<Animator>().speed = 1;
Global.mDot2.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(1, 1, 1, 1);
Global.mDot2.gameObject.GetComponent<Animator>().speed = 1;
Global.mDot3.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(1, 1, 1, 1);
Global.mDot3.gameObject.GetComponent<Animator>().speed = 1;
Global.mDot4.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(1, 1, 1, 1);
Global.mDot4.gameObject.GetComponent<Animator>().speed = 1;
Global.mDot5.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(1, 1, 1, 1);
Global.mDot5.gameObject.GetComponent<Animator>().speed = 1;

Vzriv1.SetActive(false);
		Vzriv2.SetActive(false);
		Vzriv3.SetActive(false);
		Vzriv4.SetActive(false);
		Vzriv5.SetActive(false);

    }
	
	
	IEnumerator Vzriv()
    {

yield return new WaitForSeconds(0.1f);
Vzriv1.SetActive(true);
yield return new WaitForSeconds(0.4f);
		Vzriv2.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		Vzriv3.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		Vzriv4.SetActive(true);
		yield return new WaitForSeconds(0.4f);
		Vzriv5.SetActive(true);

    }
	
	
}
