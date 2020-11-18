using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mDots : MonoBehaviour
{
    
	public GameObject Dot;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		   //this.GetComponent<Animation>()[mayak].time = 5;
			//this.gameObject.GetComponent<Animator>().enabled = false;
			
		
		if ( Dot.GetComponent<Dots>().bool1 == true ) {
			
			this.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(1, 0, 0, 1);
			this.gameObject.GetComponent<Animator>().speed = 10;
			//this.GetComponent<Animation>().Play( "mayak", 15 );
			//this.gameObject.GetComponent<Animator>().Play(mayak,0,5);
			
			//this.GetComponent<Animation>()["mayak"].time = 0.5f;
			//this.gameObject.GetComponent<Animator>().enabled = false;
			
			
//ani["field_back_anim"].time = 0.5f;
		
			//NoteFire.SetActive(true);
			//Debug.Log ( "Cool" );
			
		}
        
    }
}
