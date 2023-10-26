using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSliderScript : MonoBehaviour
{
    public GameObject[] imagesArray;
    private int currentIndex;

    void Start()
    {
      currentIndex = 0;
      setCurrentImage();
    }

    private void setCurrentImage() {
   
       for(int i=0; i < imagesArray.Length; i++) {
	  imagesArray[i].SetActive(false);
       }

       imagesArray[currentIndex].SetActive(true);
    }

    public void next() {
    
      currentIndex = (currentIndex == imagesArray.Length - 1) ? 0 : currentIndex+1; 	    
      setCurrentImage();

    }

    public void previous() {

      currentIndex = (currentIndex == 0) ? imagesArray.Length-1 : currentIndex-1;
      setCurrentImage();
	
    }


}
