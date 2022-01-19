using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider HorizontalSlider;
    public TextMesh text;
    public GameObject HorizontalSliderObj;
    public GameObject VerticalSliderObj;
    public Slider VerticalSlider;
    public Endscript end;
    public ballScript ball;
    private float Direction;
    private float Force;
    private bool dirChosen = false;
    private bool ForceChosen = false;
    private float move = 1f;
    public pinScript pins;
    private int rollsleft = 3;
    private bool impact = false;
    private bool Rended = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rollsleft>0)
        {
            if ((end.ended == true || (ball.rb.velocity.x <= 0.5f) && (ball.rb.velocity.z <= 0.5f) )&& impact)
            {
                Invoke("reRoll", 2f);
                impact = false;
                
            }
        }
        else
        {
            if(Rended)
            {
                HorizontalSliderObj.SetActive(false);
                VerticalSliderObj.SetActive(false);
                Invoke("roundEnd",2f);

            }
            return;

        }

        if (!dirChosen && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(slide());
            dirChosen = true;
        }
        else if (dirChosen && !ForceChosen && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(slide());
            Direction = HorizontalSlider.value;
            HorizontalSliderObj.SetActive(false);
            VerticalSliderObj.SetActive(true);
            StartCoroutine(slide2());
            ForceChosen = true;

        }
        else if (dirChosen && ForceChosen && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(slide2());
            VerticalSliderObj.SetActive(false);
            Force = VerticalSlider.value;
            ball.roll(Direction, Force);
            impact = true;
        }
    }

    void reRoll()
    {
        ball.rb.isKinematic = true;
        HorizontalSliderObj.SetActive(true);
        dirChosen = false;
        ForceChosen = false;
        rollsleft--;
        ball.respawn();
        pins.check();
        ball.rb.isKinematic = false ;

    }

    void roundEnd()
    {
        pins.check();
        Rended = false;
        text.gameObject.gameObject.SetActive(true);
        text.text = "Your Score was : " + pins.fell * 20;
        Time.timeScale = 0;
    }
    

    IEnumerator slide()
    {
        while (true)
        {
            if(HorizontalSlider.value >= 101f || HorizontalSlider.value<=-1f)
            {
                move *= -1f;
            }
            HorizontalSlider.value += move;
                
            yield return new WaitForSeconds(0.01f);
        }
                    
    }

    IEnumerator slide2()
    {
        while(true)
        {
            if(VerticalSlider.value ==100f)
            {
                VerticalSlider.value = 0f;
            }
            VerticalSlider.value++;
            yield return new WaitForSeconds(0.01f);
        }
    }

    


}
