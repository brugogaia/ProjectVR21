using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;
using UnityEngine.UI;

public class Morse : MonoBehaviour
{
    

	private Animator _animator; 
	private GameObject telegrafo;

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
    private KeyCode[] tastiera = new KeyCode []{ KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.KeypadPlus, KeyCode.KeypadMinus, KeyCode.Keypad1,KeyCode.Keypad2,KeyCode.Keypad3,KeyCode.Keypad4,KeyCode.Keypad5,KeyCode.Keypad6,KeyCode.Keypad7,KeyCode.Keypad8,KeyCode.Keypad9,KeyCode.Keypad0 };
    private KeyCode[] risposta=new KeyCode[]{KeyCode.Alpha5, KeyCode.KeypadPlus, KeyCode.Alpha7};
    private KeyCode[] rispostaPad=new KeyCode[]{KeyCode.Keypad5, KeyCode.KeypadPlus, KeyCode.Keypad7};
    private KeyCode[] risposta2=new KeyCode[]{KeyCode.Alpha9, KeyCode.KeypadMinus, KeyCode.Alpha3};
     private KeyCode[] risposta2Pad=new KeyCode[]{KeyCode.Keypad9, KeyCode.KeypadMinus, KeyCode.Keypad3};
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
    private bool firstsound2=true;
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
        StartGioco=false;
        telegrafo=GameObject.FindGameObjectWithTag("Telegrafo");
        _animator=telegrafo.GetComponent<Animator>(); 

    }

    
    void Update()
    {
    	//INPUT CODE

    	
    	if(StartGioco){
    	
		    	if(firstsound){
		    		audioData1.Play();
		    		firstsound=false;
		    		primaparte=true;
		    	}
	    	if(primaparte){
	    	//PRIMO SUONO 5
					   if(secondNumber==false&&thirdNumber==false){ 
					   			
					    for( int j = 0 ; j < tastiera.Length ; ++j )
					     {
					          if( Input.GetKeyDown( tastiera[j] ))
					          {		if(tastiera[j]==risposta[0]||tastiera[j]==rispostaPad[0]){
					                 Debug.Log(tastiera[j] );
					               downTimeRight=Time.time;
					               secondNumber=true;	
					              	canva5.SetActive(true);
					               rightAnswer.Play();
					               audioData2.PlayDelayed(2.0f);
					               


					                 }else{
					                 	Debug.Log($"Wrong");
					                 	wrongAnswer.Play();
					                 	audioData1.PlayDelayed(2.0f);
					                 }
					          }
					     }
					 }

					 //SECONDO SUONO +
					     if(secondNumber&&Time.time-downTimeRight>0.5){
					    	for( int k = 0 ; k < tastiera.Length ; ++k )
					     {
					          if( Input.GetKeyDown( tastiera[k] ))
					          {		if(tastiera[k]==risposta[1]||tastiera[k]==rispostaPad[1]){
					                 Debug.Log(tastiera[k] );
					                 rightAnswer.Play();
					                 secondNumber=false;
					                 thirdNumber=true;
					                 downTimeRight=Time.time;
					                 canvaPlus.SetActive(true);
					                 
					                 audioData3.PlayDelayed(2.0f);
					                 
					                 }else{
					                 	Debug.Log($"Wrong");
					                 	wrongAnswer.Play();
					                 	audioData2.PlayDelayed(2.0f);
					                 }
					          }
					     }
					 }

 //TERZO SUONO 7
  
						 if(thirdNumber&&Time.time-downTimeRight>0.5){
						    	for( int k = 0 ; k < tastiera.Length ; ++k )
						     {
						          if( Input.GetKeyDown( tastiera[k] ))
						          {		if(tastiera[k]==risposta[2]||tastiera[k]==rispostaPad[2]){
						                 Debug.Log(tastiera[k] );
						                 rightAnswer.Play();
						                 thirdNumber=false;
						                 canva7.SetActive(true);
						                 canvaEqual.SetActive(true);
						                 primaparte=false;
						                 secondaparte=true;

						                 }else{
						                 	Debug.Log($"Wrong");
						                 	wrongAnswer.Play();
						                 	 audioData3.PlayDelayed(2.0f);
						                 }
						          }
						     }
						 }
				}// fine prima parte
    	

   //OUTPUT
if(secondaparte){
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
				 			if(secondoCodiceOutput){
				 				if(Uguale(codice2,codice)){
				 					 rightAnswer.Play();
				 				Debug.Log($"UGUALI");
				 				tempo=false;
				 				canva2.SetActive(true);
				 				secondaparte=false;
				 				terzaparte=true;
				 				canvaText.SetActive(true);
				 				codice.Clear();
				 			}else{
				 				Debug.Log($"DIVERSI");
				 				wrongAnswer.Play();
				 				tempo=false;
				 				codice.Clear();
				 			}
				 			}else{
				 			
				 			if(Uguale(codice1,codice)){
				 				 rightAnswer.Play();
				 				Debug.Log($"UGUALI");
				 				tempo=false;
				 				secondoCodiceOutput=true;
				 				canva1.SetActive(true);
				 				codice.Clear();
				 			}else{
				 				Debug.Log($"DIVERSI");
				 				wrongAnswer.Play();
				 				tempo=false;
				 				codice.Clear();
				 			}
				 		}
				 				
				 		}
				 }
	} //fine seconda parte

	if(terzaparte){

		if(Input.GetKeyDown(KeyCode.Return)){
			canvaText.SetActive(false);
			canva5.SetActive(false);
    		canvaPlus.SetActive(false);
    		canva7.SetActive(false);
    		canva2.SetActive(false);
      		canva1.SetActive(false);
			canvaEqual.SetActive(false);
			audioData9.Play();
		}

		//PRIMO SUONO 9
		if(secondNumber2==false&&thirdNumber2==false){ 
					   			
					    for( int j = 0 ; j < tastiera.Length ; ++j )
					     {
					          if( Input.GetKeyDown( tastiera[j] ))
					          {		if(tastiera[j]==risposta2[0]||tastiera[j]==risposta2Pad[0]){
					                 Debug.Log(tastiera[j] );
					               downTimeRight=Time.time;
					               secondNumber2=true;	
					              	canva9.SetActive(true);
					               rightAnswer.Play();
					               audioDataMinus.PlayDelayed(2.0f);
					               


					                 }else{
					                 	Debug.Log($"Wrong");
					                 	wrongAnswer.Play();
					                 	audioData9.PlayDelayed(2.0f);
					                 }
					          }
					     }
					 }

					 //SECONDO SUONO -
					     if(secondNumber2&&Time.time-downTimeRight>0.5){
					    	for( int k = 0 ; k < tastiera.Length ; ++k )
					     {
					          if( Input.GetKeyDown( tastiera[k] ))
					          {		if(tastiera[k]==risposta2[1]||tastiera[k]==risposta2Pad[1]){
					                 Debug.Log(tastiera[k] );
					                 rightAnswer.Play();
					                 secondNumber2=false;
					                 thirdNumber2=true;
					                 downTimeRight=Time.time;
					                 canvaMinus.SetActive(true);
					                 
					                 audioDatatre.PlayDelayed(2.0f);
					                 
					                 }else{
					                 	Debug.Log($"Wrong");
					                 	wrongAnswer.Play();
					                 	audioDataMinus.PlayDelayed(2.0f);
					                 }
					          }
					     }
					 }

 //TERZO SUONO 7
  
						 if(thirdNumber2&&Time.time-downTimeRight>0.5){
						    	for( int k = 0 ; k < tastiera.Length ; ++k )
						     {
						          if( Input.GetKeyDown( tastiera[k] ))
						          {		if(tastiera[k]==risposta2[2]||tastiera[k]==risposta2Pad[2]){
						                 Debug.Log(tastiera[k] );
						                 rightAnswer.Play();
						                 thirdNumber2=false;
						                 canvaTre.SetActive(true);
						                 canvaEqual.SetActive(true);
						                 quartaparte=true;
						                 terzaparte=false;

						                 }else{
						                 	Debug.Log($"Wrong");
						                 	wrongAnswer.Play();
						                 	 audioDatatre.PlayDelayed(2.0f);
						                 }
						          }
						     }
						 }
	} //fine terza parte 

	if(quartaparte){
		
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
				 			
				 				if(Uguale(codice3,codice)){
				 					 rightAnswer.Play();
				 				Debug.Log($"UGUALI");
				 				tempo=false;
				 				canva6.SetActive(true);
				 				quartaparte=false;
				 				quintaparte=true;
				 				canvaText.SetActive(true);
				 				codice.Clear();
				 				
				 			}else{
				 				Debug.Log($"DIVERSI");
				 				wrongAnswer.Play();
				 				tempo=false;
				 				codice.Clear();
				 			}
				 		
				 				
				 		}
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
				 			
				 				if(Uguale(codiceSOS,codice)){
				 					 rightAnswer.Play();
				 				Debug.Log($"UGUALI");
				 				tempo=false;
				 				
				 				
				 				quintaparte=false;
				 				
				 				codice.Clear();
				 				
				 			}else{
				 				Debug.Log($"DIVERSI");
				 				wrongAnswer.Play();
				 				tempo=false;
				 				codice.Clear();
				 			}
				 		
				 				
				 		}
				 }
	}

}	// fine start gioco




          			
    		
    		
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
    }



    
