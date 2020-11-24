using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play1 : MonoBehaviour
{
	
	//private GameObject MCam;
	
	public GameObject aim;
	public GameObject Text1;
	
	private GameObject Dot1;
	private GameObject Dot2;
	private GameObject Dot3;
	private GameObject Dot4;
	private GameObject Dot5;
	
	private float ColorAlph;
	public GameObject TestObj;




//Вращение мышкой
public float SenX = 5, SensY = 1;
//на сколько поворачивать камеру по X и по Y
float moveY=0, moveX=-90;
//флаги движения по осям 
public bool RootX = true, //разрешаем или запрещаем перемещение по оси X 
RootY = true; //разрешаем или запрещаем перемещение по оси X
public bool TestY = true,  //включаем ограничение поворота камеры вдоль оси Y
TestX = true; //включение ограничения поворота камеры вдоль оси X
public Vector2 MinMax_Y = new Vector2(-40, 40),    //ограничение по оси Y
MinMax_X = new Vector2(-360, 360);  //ограничение по оси X
CharacterController MyPawnBody; //контроллер игрока для вращения камерой

//функция расчета угла поворота
    static float ClampAngle(float angle, float min, float max)
    {
        //если угол прошел расстояние от 0 до -360 то обнуляем его 
        if (angle < -360F) angle += 360F;
        //если угол прошел расстояние от 0 до 360 то обнуляем его 
        if (angle > 360F) angle -= 360F;
        //рассчитываем среднее значение поворота относительно угла 
        return Mathf.Clamp(angle, min, max);
    }
	
	
	
	//private GameObject TextBord;
	
	private GameObject TextDot1;
	private GameObject TextDot2;
	private GameObject TextDot3;
	private GameObject TextDot4;
	private GameObject TextDot5;
	
	private GameObject TextText1;
	private GameObject BordTextSprite;
	private GameObject p1;
	/*private GameObject TextDot3;
	private GameObject TextDot4;
	private GameObject TextDot5; */
	
	
	
	
	
	
	
	void Awake()
    {
		
	
		//TextBord = GameObject.Find("TextBord");


		BordTextSprite = GameObject.Find("BordTextSprite");
		p1 = GameObject.Find("p1");
		
		TextDot1 = GameObject.Find("TextDot1");
		 TextDot2 = GameObject.Find("TextDot2");
		TextDot3 = GameObject.Find("TextDot3");
		TextDot4 = GameObject.Find("TextDot4");
		TextDot5 = GameObject.Find("TextDot5");

		
	}
	
    // Start is called before the first frame update
    void Start()
    {
		
TextDot1.SetActive(false);
TextDot2.SetActive(false);
TextDot3.SetActive(false);
TextDot4.SetActive(false);
TextDot5.SetActive(false);
		
		//MCam = GameObject.Find("MCam" );
		
		
		//получаем тело нашего игрока
MyPawnBody = this.GetComponent<CharacterController>();


Dot1 = GameObject.Find("Dot1" );
Dot2 = GameObject.Find("Dot2" );
Dot3 = GameObject.Find("Dot3" );
Dot4 = GameObject.Find("Dot4" );
Dot5 = GameObject.Find("Dot5" );
 
 //yield WaitForSeconds(2s);
 //Debug.Log("time");
 
 //Dot1.gameObject.name = "vrag2";
 
 StartCoroutine(mDotsStart());
        
    }

    // Update is called once per frame
    void Update()
    {
		
		//GameObject[] TextDots;
		
		//TextDots = GameObject.FindGameObjectsWithTag("TextDots");
		//TextDots.SetActive(false);
		//Debug.Log( TextDots.Length );
		
		
		
		//вращение камеры с клавиатуры
		/* if (Input.GetKey(KeyCode.LeftArrow))
		transform.Rotate(0.0f, -1f, 0.0f, Space.World);
	    if (Input.GetKey(KeyCode.RightArrow))
		transform.Rotate(0.0f, 1f, 0.0f, Space.World);
	    if (Input.GetKey(KeyCode.UpArrow))
		transform.Rotate(0.0f, 0.0f, -1f, Space.Self);
	    if (Input.GetKey(KeyCode.DownArrow))
		transform.Rotate(0.0f, 0.0f, 1f, Space.Self); */
	
	
	
	
	
	 //получаем угол на который мышь улетела от центра экрана по Y
        if (RootY)  moveY -= Input.GetAxis("Mouse Y") * SensY;
        //ограничиваем угол поворота камеры чтобы она не вращалась под ноги 
        if(TestY)   moveY = ClampAngle(moveY, MinMax_Y.x, MinMax_Y.y); 
        //получаем угол на который мышь улетела от центра экрана по Х
        if (RootX)  moveX += Input.GetAxis("Mouse X") * SenX;
         //ограничиваем угол поворота камеры чтобы она не вращалась по оси X
        if (TestX)  moveX = ClampAngle(moveX, MinMax_X.x, MinMax_X.y); 
        //поворачиваем тело персонажа по осям 
        MyPawnBody.transform.rotation = Quaternion.Euler(moveY, moveX, 0);
		
	
	
	
	//Debug.Log( aim.transform.position );
	
	
	
	
	
	
	
	//ЛУЧ
	//сюда запишется инфо о пересечении луча, если оно будет
    RaycastHit hit;
    //сам луч, начинается от позиции этого объекта и направлен в сторону цели
    Ray ray = new Ray(transform.position, aim.transform.position - transform.position);
    //пускаем луч
    Physics.Raycast(ray, out hit);
	
	//просто для наглядности рисуем луч в окне Scene
	Debug.DrawLine(ray.origin, hit.point,Color.red);
	
	
	//если луч с чем-то пересёкся, то..
    if ( hit.collider != null ){
	
	if ( hit.collider.gameObject == Dot1.gameObject ){
		
		//Debug.Log("Дот 1");
		Text1.GetComponent<Text>().text = "Объект: Дот 1";
		//GameObject.FindGameObjectWithTag("TextDots").SetActive(false);
		Global.TextDot1.SetActive(true);
		Global.TextDot2.SetActive(false);
		Global.TextDot3.SetActive(false);
		Global.TextDot4.SetActive(false);
		Global.TextDot5.SetActive(false);
		Dot1.GetComponent<Dots>().bool1 = true;
		//Global.Time2 = 0;
		
		
	} else if ( hit.collider.gameObject == Dot2.gameObject ) { 
	Text1.GetComponent<Text>().text = "Объект: Дот 2";
	//GameObject.FindGameObjectWithTag("TextDots").SetActive(false);
	Global.TextDot1.SetActive(false);
		Global.TextDot2.SetActive(true);
		Global.TextDot3.SetActive(false);
		Global.TextDot4.SetActive(false);
		Global.TextDot5.SetActive(false);
		Dot2.GetComponent<Dots>().bool1 = true;
	}
	else if ( hit.collider.gameObject == Dot3.gameObject ) { 
	//Debug.Log("Дот 3");
	Text1.GetComponent<Text>().text = "Объект: Дот 3"; 
	Global.TextDot3.SetActive(true);
	Global.TextDot1.SetActive(false);
		Global.TextDot2.SetActive(false);
		Global.TextDot4.SetActive(false);
		Global.TextDot5.SetActive(false);
		Dot3.GetComponent<Dots>().bool1 = true;
	}
	else if ( hit.collider.gameObject == Dot4.gameObject ) { 
	Text1.GetComponent<Text>().text = "Объект: Дот 4";
	Global.TextDot4.SetActive(true);
 Global.TextDot1.SetActive(false);
		Global.TextDot2.SetActive(false);
		Global.TextDot3.SetActive(false);
		Global.TextDot5.SetActive(false);
		Dot4.GetComponent<Dots>().bool1 = true;
	}
	else if ( hit.collider.gameObject == Dot5.gameObject ) { 
	Text1.GetComponent<Text>().text = "Объект: Дот 5";
	Global.TextDot5.SetActive(true);
Global.TextDot1.SetActive(false);
		Global.TextDot2.SetActive(false);
		Global.TextDot3.SetActive(false);
		Global.TextDot4.SetActive(false);
		Dot5.GetComponent<Dots>().bool1 = true;
	}
	
	} else {
		
		//TextDot1.SetActive(false);
		
	}
	
	
	//Debug.Log ( aim.transform.position )
	//Debug.Log ( "Play: " + this.transform.position );
	//Debug.Log ( "aim: " + aim.transform.position );
	//Debug.Log ( "ray: " + ray );
	//Debug.Log ( "Dot1: " + Dot1.transform.position );
	//Debug.Log ( "Distance: " + Vector3.Distance(aim.transform.position, Dot1.transform.position) );
	
	//Debug.Log ( "Color: " + BordTextSprite.GetComponent<SpriteRenderer>().color );
	
	
	//Исчезновение текста по мере отдаления
	//Для UI
	
	//Для 3D
	/* 
	ColorAlph = 0.1f / Vector3.Distance(aim.transform.position, Dot1.transform.position);
	TextText1.GetComponent<TextMesh>().color = new UnityEngine.Color(1f, 1f, 1f, ColorAlph );
	BordTextSprite.GetComponent<SpriteRenderer>().color  = new UnityEngine.Color(1f, 1f, 1f, ColorAlph );
	p1.GetComponent<SpriteRenderer>().color  = new UnityEngine.Color(1f, 1f, 1f, ColorAlph ); */
	
	//Debug.Log ( MCam.GetComponent<Camera>().WorldToScreenPoint(Dot1.transform.position) );
	
	
	
	



	
	
	
	
	//Выход
	if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
		
		
		
	
	
	}
	
	
	
	//Появления маячков
	IEnumerator mDotsStart()
    {

yield return new WaitForSeconds(0.1f);
Global.mDot1.SetActive(true);       
yield return new WaitForSeconds(0.5f);
Global.mDot2.SetActive(true);
yield return new WaitForSeconds(0.5f);
Global.mDot3.SetActive(true);
yield return new WaitForSeconds(0.5f);
Global.mDot4.SetActive(true);
yield return new WaitForSeconds(0.5f);
Global.mDot5.SetActive(true);

    }
	
	
        
}
