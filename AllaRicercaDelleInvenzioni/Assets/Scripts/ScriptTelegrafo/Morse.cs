using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;
using UnityEngine.UI;

public class Morse : MonoBehaviour
{
    private Animator _animator; 
	private GameObject telegrafo;
	[SerializeField] private GameObject _exit;

	public bool StartGioco=false;

	private float downTimeRight;
   	private float downTimeRight2;
	private bool secondNumber=false;
    private bool thirdNumber=false;
    private bool secondNumber2=false;
    private bool thirdNumber2=false;
    private bool secondaparte=false;
    private bool terzaparte=false;
    private bool quartaparte=false;
    private bool quintaparte=false;
    private bool primaparte=false;
    private List<KeyCode> tastiera = new List<KeyCode>{ KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.KeypadPlus, KeyCode.KeypadMinus, KeyCode.Minus, KeyCode.Equals, KeyCode.Keypad1,KeyCode.Keypad2,KeyCode.Keypad3,KeyCode.Keypad4,KeyCode.Keypad5,KeyCode.Keypad6,KeyCode.Keypad7,KeyCode.Keypad8,KeyCode.Keypad9,KeyCode.Keypad0 };
    private List<KeyCode> risposta=new List<KeyCode>{KeyCode.Alpha5, KeyCode.Equals, KeyCode.Alpha7};
    private List<KeyCode> rispostaPad=new List<KeyCode>{KeyCode.Keypad5,KeyCode.KeypadPlus, KeyCode.Keypad7};
    private List<KeyCode> risposta2=new List<KeyCode>{KeyCode.Alpha9, KeyCode.Minus, KeyCode.Alpha3};
    private List<KeyCode> rispostaPad2=new List<KeyCode>{KeyCode.Keypad9, KeyCode.KeypadMinus, KeyCode.Keypad3};
    private List<int> codice= new List<int>();
    private List<int> codice1= new List<int>(){1,2,2,2,2};
    private List<int> codice2= new List<int>(){1,1,2,2,2};
    private List<int> codice3= new List<int>(){2,1,1,1,1};
    private List<int> codiceSOS= new List<int>(){1,1,1,2,2,2,1,1,1};
	
	 public AudioSource audioData1;
    public AudioSource audioData2;
    public AudioSource audioData3;
    public AudioSource audioData9;
    public AudioSource audioDataMinus;
    public AudioSource audioDatatre;
    public AudioSource wrongAnswer;
    public AudioSource rightAnswer;
    public AudioSource bip;
    private bool firstsound=true;
    private bool tempo=false;
    private bool secondoCodiceOutput=false;
	public GameObject canva5;
    public GameObject canvaPlus;
    public GameObject canva7;
    public GameObject canva1;
    public GameObject canva2;
    public GameObject canvaText;
    public GameObject canvaText2;
    public GameObject canvaEqual;
    public GameObject canva9;
    public GameObject canvaMinus;
    public GameObject canva6;
    public GameObject canvaTre;
    public GameObject canvaFineGioco;
    public GameObject canvaSpiegazione;
    public GameObject canvaSpiegazione1;
void Start()
    {
    	canva5.SetActive(false);
    	canvaPlus.SetActive(false);
    	canva7.SetActive(false);
    	canva2.SetActive(false);
      	canva1.SetActive(false);
      	canvaText.SetActive(false);
      	canvaText2.SetActive(false);
        canvaEqual.SetActive(false);
        canva9.SetActive(false);
        canva6.SetActive(false);
        canvaTre.SetActive(false);
        canvaMinus.SetActive(false);
        canvaFineGioco.SetActive(false);
        canvaSpiegazione1.SetActive(true);
        canvaSpiegazione.SetActive(false);
		_exit.SetActive(false);
        StartGioco=false;
        telegrafo=GameObject.FindGameObjectWithTag("Telegrafo");
        _animator=telegrafo.GetComponent<Animator>(); 

    }

void Update()
    {
    	if(StartGioco){
    	
		    	if(firstsound){
		    		audioData1.Play();
		    		firstsound=false;
		    		primaparte=true;
		    	}
	    	if(primaparte){
	    	//PRIMO SUONO 5
					   if(secondNumber==false&&thirdNumber==false){ 
					   	for( int j = 0 ; j < tastiera.Count ; ++j )
					     {
					     	if( Input.GetKeyDown( tastiera[j] )){
								if(Gioco(tastiera[j], risposta[0], rispostaPad[0], canva5, canvaEqual, audioData1, audioData2, secondNumber, thirdNumber))
					   				secondNumber=true;
					    	}
					   	}
					 }
			//SECONDO SUONO +
					     if(secondNumber&&Time.time-downTimeRight>0.5){
					    	for( int k = 0 ; k < tastiera.Count ; ++k ){
					          if( Input.GetKeyDown( tastiera[k] ))
								if(Gioco(tastiera[k], risposta[1], rispostaPad[1], canvaPlus, canvaEqual, audioData2, audioData3, secondNumber, thirdNumber)){
					   				secondNumber=false;
					   				thirdNumber=true;
					          	}
					          }
					 	}
		 	//TERZO SUONO 7
   							if(thirdNumber&&Time.time-downTimeRight>0.5){
						    	for( int k = 0 ; k < tastiera.Count ; ++k ){
						          if( Input.GetKeyDown( tastiera[k] ))
						          {		
						          			if(Gioco(tastiera[k], risposta[2], rispostaPad[2], canva7, canvaEqual, audioData3, audioData1, secondNumber, thirdNumber)){
						   						thirdNumber=false;
						   						primaparte=false;
						   						secondaparte=true;
						   						canvaSpiegazione.SetActive(true);
						   					}
						   			}
						     }
						 }
				}// fine prima parte
 //OUTPUT
if(secondaparte){
	if(!secondoCodiceOutput){
	if(Gioco2(codice, codice1, canva1)){
		secondoCodiceOutput=true;
	}
}
	if(secondoCodiceOutput){
		if(Gioco2(codice, codice2, canva2)){
			canvaSpiegazione.SetActive(false);
			canvaText.SetActive(true);
			terzaparte=true;
			secondaparte=false;
		}
	}
	} //fine seconda parte

if(terzaparte){
		if(Input.GetKeyDown(KeyCode.Return)){
			canvaSpiegazione1.SetActive(false);
			canvaText.SetActive(false);
			canva5.SetActive(false);
    		canvaPlus.SetActive(false);
    		canva7.SetActive(false);
    		canva2.SetActive(false);
      		canva1.SetActive(false);
			canvaEqual.SetActive(false);
			audioData9.Play();
		}
		//PRIMOSUONO 9
		 if(secondNumber2==false&&thirdNumber2==false){ 
					   	for( int j = 0 ; j < tastiera.Count ; ++j )
					     {
					     	if( Input.GetKeyDown( tastiera[j] )){
								if(Gioco(tastiera[j], risposta2[0], rispostaPad2[0], canva9, canvaEqual, audioData9, audioDataMinus, secondNumber2, thirdNumber2))
					   				secondNumber2=true;
					    	}
					   			
						}
					 }
			//SECONDO SUONO +
		if(secondNumber2&&Time.time-downTimeRight>0.5){
					    	for( int k = 0 ; k < tastiera.Count ; ++k ){
					          if( Input.GetKeyDown( tastiera[k] ))
								if(Gioco(tastiera[k], risposta2[1], rispostaPad2[1], canvaMinus, canvaEqual, audioDataMinus, audioDatatre, secondNumber2, thirdNumber2)){
					   				secondNumber2=false;
					   				thirdNumber2=true;
					          	}
					          }
					 	}			     
		 	//TERZO SUONO 7
   		if(thirdNumber2&&Time.time-downTimeRight>0.5){
			for( int k = 0 ; k < tastiera.Count ; ++k ){
				if( Input.GetKeyDown( tastiera[k] )) {		
					if(Gioco(tastiera[k], risposta2[2], rispostaPad2[2], canvaTre, canvaEqual, audioDatatre, audioData1, secondNumber2, thirdNumber2)){
						 thirdNumber2=false;
						 terzaparte=false;
						 quartaparte=true;
					}	          			
			}
		 }
		}						          	    				
	} //fine terza parte 

	if(quartaparte){
		if(Gioco2(codice, codice3, canva6)){
			quartaparte=false;
			quintaparte=true;
			canvaText.SetActive(true);
		}

	}//fine quarta parte
	
	if(quintaparte){
 		if(Input.GetKeyDown(KeyCode.Return)){
			canvaText.SetActive(false);
			canva9.SetActive(false);
    		canvaMinus.SetActive(false);
    		canvaTre.SetActive(false);
    		canva6.SetActive(false);
			canvaEqual.SetActive(false);
			canvaText2.SetActive(true);
		}
		if(Gioco2(codice, codiceSOS, canvaFineGioco)){
			quintaparte=false;
			canvaText2.SetActive(false);
			_exit.SetActive(true);
		}
	}

}   // fine start gioco

		if (Input.GetKeyDown(KeyCode.L))
		{
			_exit.SetActive(true);
		}
 } //fine update

  private bool Uguale(List<int> list1, List<int> list2){
  	if(list1.Count!=list2.Count)
  		return false;
 	for(int g=0;g<list1.Count;g++){
 		if(list1[g]!=list2[g]){
 		return false;}
 		 }
		return true;
 		}
    
private bool Gioco( KeyCode tastiera, KeyCode risposta, KeyCode rispostaPad, GameObject canva, GameObject canvaEqual, AudioSource audio1, AudioSource audio2, bool secondNumber, bool thirdNumber ){
	 				if(tastiera==risposta||tastiera==rispostaPad){
					                 Debug.Log(tastiera );
					               downTimeRight=Time.time;
					              	if(thirdNumber){
					              		canvaEqual.SetActive(true);
					              	}
					              	canva.SetActive(true);
					              	rightAnswer.Play();
					              	if(!thirdNumber){
					                audio2.PlayDelayed(2.0f);
					            	}
					               return true;
 									}else{
					                 	Debug.Log($"Wrong");
					                 	wrongAnswer.Play();
					                 	audio1.PlayDelayed(2.0f);
					                 }
					                 return false;
					          }
private bool Gioco2(List <int> codice, List<int> codiceConfronto, GameObject canva){
	if(Input.GetKeyDown(KeyCode.Space)){
				 	bip.Play();
				 	_animator.SetBool("Dot", true);
				 	downTimeRight=Time.time;
				 	
				 }
				 if(Input.GetKeyUp(KeyCode.Space)){
				 	_animator.SetBool("Dot", false);
				 	 tempo=true;
				 	 bip.Stop();
				 	if(Time.time-downTimeRight>0.3){
				 		codice.Add(2);
				 		Debug.Log($"linea");
				 		
				 	}else{
				 		Debug.Log($"punto"); 
				 		codice.Add(1);
				 		}
				 }
					if(tempo){
				 		downTimeRight2=Time.time;
				 		if(Time.time-downTimeRight>2){
				 			if(Uguale(codiceConfronto,codice)){
				 					 rightAnswer.Play();
				 					Debug.Log($"UGUALI");
				 					tempo=false;
				 					
				 					codice.Clear();
				 					canva.SetActive(true);
				 					return true;
				 				}else{
				 					Debug.Log($"DIVERSI");
				 					wrongAnswer.Play();
				 					tempo=false;
				 					codice.Clear();
				 					return false;
				 			}
				 		}
				 }
				 return false;
}
}