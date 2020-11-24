using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotsCol : MonoBehaviour
{
    
	public GameObject MCam;
	public GameObject Dot;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		Vector3 DotScreenPos = MCam.GetComponent<Camera>().WorldToScreenPoint(Dot.transform.position);
		Vector3 ThisScreenPos = MCam.GetComponent<Camera>().WorldToScreenPoint(this.transform.position);
		
		this.transform.localPosition  = new Vector3( DotScreenPos.x - 450, DotScreenPos.y, 0 );
		
		//ThisScreenPos.x = 250;
		
		//Debug.Log( "Дот: " + MCam.GetComponent<Camera>().WorldToScreenPoint(Dot.transform.position ) );
		//Debug.Log( "ДотCol: " + MCam.GetComponent<Camera>().WorldToScreenPoint(this.transform.position ) );
		//Debug.Log( "DotScreenPos.x: " + DotScreenPos.x );
		//Debug.Log( "ThisScreenPos.x: " + ThisScreenPos.x );
		//Debug.Log( "ThisScreenPos.y: " + ThisScreenPos.y );
		//Debug.Log( "ThisScreenPos.z: " + ThisScreenPos.z );
        
    }
}
