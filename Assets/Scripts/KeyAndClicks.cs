using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyAndClicks : MonoBehaviour
{
    public GameObject light;

    private bool lightOn = true;
    //public Text myText;
    private int jumps;

    public int offset = 0;
    private Vector3 players_Last_Position;//gia na kratame thn teleutaia thesh tou paixth

    private int megethos;//teleutaio erwthma
    private int mphke = 0;//an xanapaei parapanw apo 1 fores sto epipedo N

    void Start()
    {
        players_Last_Position = transform.position;
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        this.enabled = false;
        GetNCloseWindow s = GetComponent<GetNCloseWindow>();
        yield return new WaitUntil(() => s.E >= 1);
        megethos = s.X;
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jumps++;
            //myText.text = "Jumps: " + jumps;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            if (lightOn == true)
            {
                light.SetActive(false);
                lightOn = false;
            }
            else
            {
                light.SetActive(true);
                lightOn = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) // Left CLick
        {
            if (this.transform.position.x > 0)
            {
                InitializeScore();
            }
        }
    }
    void InitializeScore()
    {
        float x = transform.position.y;
        float y = players_Last_Position.y;
        players_Last_Position = this.transform.position;
        if ((x>megethos-1)&&(x<megethos) && (mphke == 0))
        {
            GetNCloseWindow s = GetComponent<GetNCloseWindow>();
            s.AddScore(100);
            mphke = 1;
        }
        if (y > x)
        {
            float b = (y - x);
            int c = (int)Mathf.Round(b);//epipeda ptwshs
            Debug.Log("c is:" + c);
            if (c == 1)
            {
                mphke = 0;
            }
            if (c > 1)
            {
                mphke = 0;
                GetNCloseWindow s = GetComponent<GetNCloseWindow>();
                s.AddScore((c-1)* 10);                
            }
        }
    }

}