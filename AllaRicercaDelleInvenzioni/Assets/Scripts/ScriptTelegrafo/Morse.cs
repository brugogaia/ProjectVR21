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
    private bool secondaparte=false;
    private KeyCode[] tastiera = new KeyCode []{ KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.KeypadPlus };
    private KeyCode[] risposta=new KeyCode[]{KeyCode.Alpha5, KeyCode.KeypadPlus, KeyCode.Alpha7};
    private List<int> codice= new List<int>();
    private List<int> codice1= new List<int>(){1,2,2,2,2};
    private List<int> codice2= new List<int>(){1,1,2,2,2};


    public AudioSource audioData1;
    public AudioSource audioData2;
    public AudioSource audioData3;
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
    public GameObject canvaEqual;
   
  
    void Start()
    {
    	canva5.SetActive(false);
    	canvaPlus.SetActive(false);
    	canva7.SetActive(false);
    	canva2.SetActive(false);
      	canva1.SetActive(false);
        canvaEqual.SetActive(false);
        StartGioco=false;
        telegrafo=GameObject.FindGameObjectWithTag("Telegrafo");
        _animator=telegrafo.GetComponent<Animator>(); 

    }

    
    void Update()
    {
    	//INPUT CODE

    	//PRIMO SUONO 5
    	if(StartGioco){
    	
    	if(firstsound){
    		audioData1.Play();
    		firstsound=false;
    	}
   if(secondNumber==false&&thirdNumber==false){ 
   			
    for( int j = 0 ; j < tastiera.Length ; ++j )
     {
          if( Input.GetKeyDown( tastiera[j] ))
          {		if(tastiera[j]==risposta[0]){
                 Debug.Log(tastiera[j] );
               downTimeRight=Time.time;
               secondNumber=true;	
              	canva5.SetActive(true);
               rightAnswer.Play();
               audioData2.PlayDelayed(4.0f);
               


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
          {		if(tastiera[k]==risposta[1]){
                 Debug.Log(tastiera[k] );
                 rightAnswer.Play();
                 secondNumber=false;
                 thirdNumber=true;
                 downTimeRight=Time.time;
                 canvaPlus.SetActive(true);
                 
                 audioData3.PlayDelayed(4.0f);
                 
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
          {		if(tastiera[k]==risposta[2]){
                 Debug.Log(tastiera[k] );
                 rightAnswer.Play();
                 thirdNumber=false;
                 canva7.SetActive(true);
                 canvaEqual.SetActive(true);
                 secondaparte=true;
                 }else{
                 	Debug.Log($"Wrong");
                 	wrongAnswer.Play();
                 	 audioData3.PlayDelayed(2.0f);
                 }
          }
     }
 }
    	

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
 			}else{
 				Debug.Log($"DIVERSI");
 				wrongAnswer.Play();
 				tempo=false;
 				codice.Clear();
 			}
 		}
 				
 		}
 }
}
}




          			
    		
    		
 }

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



    
