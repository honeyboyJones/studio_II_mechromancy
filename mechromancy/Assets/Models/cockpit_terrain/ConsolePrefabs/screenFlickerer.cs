using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class screenFlickerer : MonoBehaviour
{
    public GameObject myScreen;
    public GameObject myButton;
    Material myMat;
    Color startScreenCol;
    //float intensity;
    //float rotation;
    //float speed;
    //float tiling;
    Text myText;
    Color startButtonCol;
    Color newCol;
    Color newDarkCol;
    public float interval = 60f;
    float startInt;
    bool int1Reset = false;
    public float interval2 = 19f;
    float startInt2;
    bool int2Reset = false;
    public float interval3 = 45f;
    float startInt3;
    bool int3Reset = false;
    public float myRot;
    public Color brightShift;
    bool isLerping1 = false;
    bool isLerping2 = false;
    bool isLerping3 = false;
    bool isLerpingText;
    // Start is called before the first frame update
    void Start()
    {
        startInt = interval;
        myMat = myScreen.GetComponent<Renderer>().material;
        startScreenCol = myMat.GetColor("Color_dfaf888f0e494306b381c5ec974d63e3");
        newCol = startScreenCol+brightShift;
        newDarkCol = startScreenCol -(brightShift*2);
        startButtonCol = myButton.GetComponent<Text>().color;
        myText = myButton.GetComponent<Text>();
        //myMat.GetFloat("intensity");
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;
        interval2 -= Time.deltaTime;
        interval3 -= Time.deltaTime;

        //lerping the screen color
        if (Mathf.Abs(interval) <= 0.1f && isLerping1!= true){
            Debug.Log("we made it to IF");
            StartCoroutine(CycleMaterial(startScreenCol, newCol, 0.2f, myMat, isLerping1));           
        }
        if (int1Reset == true){
           StartCoroutine(CycleMaterial(newCol, startButtonCol, 0.2f, myMat, isLerping1)); 
        }
        if(Mathf.Abs(interval) >= 0.1f && isLerping1!= true){
            myMat.SetColor("Color_dfaf888f0e494306b381c5ec974d63e3",startScreenCol);
        } 

        //TEXT ONLY lerping
        if(Mathf.Abs(interval) <= 0.1f && isLerpingText!= true){
           // StartCoroutine(CycleText(startButtonCol, newCol, 0.2f, myText)); 
        }

    if (interval < 0){interval = startInt+Random.Range(-.01f,0.01f); int1Reset = true;}
    else{int1Reset = false;}

        //lerping the screen color
        if (Mathf.Abs(interval2) <= 0.1f && isLerping2!= true){
            Debug.Log("we made it to IF");
            StartCoroutine(CycleMaterial(startScreenCol, newCol, 0.2f, myMat, isLerping2));           
        }
        if (int2Reset == true){
           StartCoroutine(CycleMaterial(newCol, startButtonCol, 0.2f, myMat, isLerping2)); 
        }
        if(Mathf.Abs(interval2) >= 0.1f && isLerping2!= true){
            myMat.SetColor("Color_dfaf888f0e494306b381c5ec974d63e3",startScreenCol);
        } 

        //TEXT ONLY lerping
        if(Mathf.Abs(interval2) <= 0.1f && isLerpingText!= true){
           // StartCoroutine(CycleText(startButtonCol, newCol, 0.2f, myText)); 
        }
    if (interval2 < 0){interval2 = startInt2+Random.Range(-.05f,.05f);int2Reset = true;}
    else{int2Reset = false;}


    if (interval3 < 0){interval3 = startInt3+Random.Range(-startInt3/2,startInt3/4);}

    
    }

        IEnumerator CycleMaterial(Color startColor, Color endColor, float cycleTime, Material mat, bool isLerping)
    {
        Debug.Log("we're Lerping");
        isLerping = true;
        float currentTime = 0;
        while (currentTime < cycleTime)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / cycleTime;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            mat.SetColor("Color_dfaf888f0e494306b381c5ec974d63e3",currentColor);
            yield return null;
        }
        isLerping = false;
 
    }
           /* IEnumerator CycleText(Color startColor, Color endColor, float cycleTime, Text myText)
    {
        Debug.Log("we're Lerping TEXT");
        isLerpingText = true;
        float currentTime = 0;
        float halfTime = cycleTime/2;
        float secondHalf = 0;
        while (currentTime < cycleTime)
        {
            if(currentTime > halfTime){
                currentTime += Time.deltaTime;
                float t = currentTime / halfTime;
                Color currentColor = Color.Lerp(startColor, endColor, t);
                myButton.GetComponent<Text>().color = currentColor;
            }
            if(currentTime <= cycleTime){
                currentTime += Time.deltaTime;
                secondHalf += Time.deltaTime;
                float t = secondHalf / halfTime;
                Color currentColor = Color.Lerp(endColor, startColor, t);
                myButton.GetComponent<Text>().color = currentColor;               
            }
            yield return null;
        }
        isLerpingText = false;
 
    }*/
}
