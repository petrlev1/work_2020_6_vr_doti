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
	
	public GameObject Camera11;
	public float WaitTime;
	public int ResetTime = 55;
	
	
	
	public float timer = 0.0f;
     public int seconds;
     public bool keepTiming = true;
	 
	 public float timer2 = 0.0f;
     public int seconds2;
	
	
	


	
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

PlayerPrefs.SetFloat( "Pos1", Camera11.transform.rotation.y );
//Debug.Log ( "Переменная равна: " + ((int)(Camera11.transform.rotation.x * 100)) / 100f );
        
    }

    
    void Update()
    {
		
		//Debug.Log ( "rot: " + this.transform.rotation.y );
		//Debug.Log ( "rot2: " + Mathf.RoundToInt(this.transform.rotation.y) );
		//Debug.Log ( "per: " + PlayerPrefs.GetFloat("Pos1"));
		//Debug.Log ( "sum: " + (this.transform.rotation.x + PlayerPrefs.GetFloat("Pos1")) );
		//Debug.Log ( "Dist: " + Vector3.Distance( PlayerPrefs.GetFloat("Pos1"), this.transform.rotation.x ) );
		
		//StartCoroutine( Pos1());
	
	
	
	
	
	//Таймер и сравнивание переменных
	      
		  Timer();
		  Timer2();
		  //Text1.GetComponent<Text>().text = seconds.ToString();
		   
		   float VarNow = ((int)(Camera11.transform.rotation.y * 10)) / 10f;
		   float VarSave = ((int)(PlayerPrefs.GetFloat("Pos1") * 10)) / 10f;
		   
		  //Общее время
		  if (seconds > 1)
         {
			 
			 //Записываем переменную 1й позиции	
PlayerPrefs.SetFloat( "Pos1", Camera11.transform.rotation.y );
//Debug.Log ( "Переменная равна: " + VarNow );
			 //Debug.Log ( Camera11.transform.rotation.x );
			 //Text1.GetComponent<Text>().text = seconds.ToString();
             ResetTimer();
         }
		 
		 if ( VarNow == VarSave ) {
			 //Text1.GetComponent<Text>().text = "Переменные равны! " + seconds2.ToString();
			 ResetTimer();
			 
			 if ( seconds2 > ResetTime ) {
				 
				 //Text1.GetComponent<Text>().text = "Игра обновлена";
				 StartCoroutine( Wait1());
			 }
			
		 } else {
			 
			 //Text1.GetComponent<Text>().text = seconds.ToString();
			 ResetTimer2();
			 
		 }
		 
		 //Text1.GetComponent<Text>().text = "COOl";
		 
		 /* if ( ((int)(Camera11.transform.rotation.x * 100)) / 100f == ((int)(PlayerPrefs.GetFloat("Pos1") * 100)) / 100f ) {
			 Debug.Log ( "Переменные равны: " );
			 if ( seconds > 13 ) {
				 //Debug.Log ( "Перезагрузка игры!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" );
			 }
			 //Debug.Log ( "Camera11.transform.rotation.x:" + ((int)(Camera11.transform.rotation.x * 100)) / 100f );
			 //Debug.Log ( "PlayerPrefs.GetFloat: " + ((int)(PlayerPrefs.GetFloat("Pos1") * 100)) / 100f );
		 } else {
				//Debug.Log ( "Переменные НЕ равны: " );
		 } */
			
		
		
		
		
		
		
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
		   
	   //Text1.GetComponent<Text>().text = "COOl";
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

Global.TextDot1.SetActive(false);
Global.TextDot2.SetActive(false);
Global.TextDot3.SetActive(false);
Global.TextDot4.SetActive(false);
Global.TextDot5.SetActive(false);

Vzriv1.SetActive(false);
		Vzriv2.SetActive(false);
		Vzriv3.SetActive(false);
		Vzriv4.SetActive(false);
		Vzriv5.SetActive(false);
		
		NoteFire.SetActive(false);
		
		ResetTimer2();

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
	
	
	
	
	
	public void Timer()
     {
         // seconds
         timer += Time.deltaTime;
         // turn float seonds to int
         seconds = (int)(timer % 60);
         //print(seconds);
     }
 
     public void ResetTimer()
     {
         // seconds
         timer += Time.deltaTime;
         // turn float seonds to int
         seconds = (int)(timer % 60);
         //print(seconds);
 timer = 0.0f;
     }
 
     public void StopTimer()
     {
         if (keepTiming)
         {
             // seconds
             timer += Time.deltaTime;
             // turn float seonds to int
             seconds = (int)(timer % 60);
             print(seconds);
         }
 
         if (seconds > 4)
         {
             // stop and record time
             keepTiming = false;
             print(seconds);
         }
		 
	 }
	 
	 public void Timer2()
     {
         // seconds
         timer2 += Time.deltaTime;
         // turn float seonds to int
         seconds2 = (int)(timer2 % 60);
         //print(seconds);
     }
 
     public void ResetTimer2()
     {
         // seconds
         timer2 += Time.deltaTime;
         // turn float seonds to int
         seconds2 = (int)(timer2 % 60);
         //print(seconds);
 timer2 = 0.0f;
     }
	 
	
	
}
