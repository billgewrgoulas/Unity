using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Numerics;
//using UnityStandardAssets.Characters.FirstPerson;

public class GetNCloseWindow : MonoBehaviour
{

    public GameObject UI;
    public GameObject Cube;

    public string N;
    public InputField p;

    private static Vector3 a;//gia thn kainourgia thesh tou antikeimenou
    private static int e = 0;//gia to waitUntil
    private static int x = 0;//gia to megethos tou perivalontos mas

    private bool gameOver;
    private bool restart;

    private static Vector3 spotLight;//gia thn thesh twn 2 spotlight
    private static Vector3 spotLight1;

    public Text mText;//keimeno gia to score
    public Text m1Text;//ketimeno gia ta lifes
    public Text restartText;
    public Text gameOverText;
    private int score = 100;
    private int lifes = 4;
    public int[] eikonikoiKuboi = new int[5] { 1, 2, 3, 0, 1 };
    public int[] diathEikonKuboi = new int[5] { 0, 0, 0, 0, 0 };
    //0-->kitrino,1-->kokkino,2-->prasino,3-->mple,4-->cyan

    Color[] colors = new Color[5] { Color.blue, Color.yellow, Color.cyan, Color.red, Color.green }; //gia thn tyxaia epilogh xrwmatos

    // Use this for initialization
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        //score = 100;
        mText.text = "Score: " + 100;
        m1Text.text = "Lifes: " + 4;
        p.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        Text PlaceHolder = UI.transform.Find("Panel").Find("InputField").GetComponent<InputField>().placeholder.GetComponent<Text>();
        if (PlaceHolder == null)
            return;
        // Press the space key to change the Text message.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Placeholder: " + PlaceHolder.text.ToString());
            Debug.Log("Text: " + UI.transform.Find("Panel").Find("InputField").GetComponent<InputField>().text);
            UI.SetActive(false);
            x = int.Parse(UI.transform.Find("Panel").Find("InputField").GetComponent<InputField>().text);
            int y = x - 1;//mallon den mas xreiazetai
            Wall1.walls(x, x, true);
            Wall2.walls(x, x, true);
            Wall3.walls(x, x, true);
            Wall4.walls(x, x, true);
            Wall5.walls(x, x, true);
            //Wall6.walls(x, x, true);
            int offset = 1;
            for (int j = 1; j < x + 1; j++)
            {
                for (int i = 1; i < x; i++)
                {
                    if (offset == 0)//edw isws xreiastei na kanoume 1 random apexw kai na to kratame giati leei to epipedo 1 to gemizoume me kubakia idiou xrwmatos(den eimai teleiws sigouros omws)
                    {
                        GameObject go = Instantiate(Cube, new Vector3(0, 0 + offset, i * 1.0f), Quaternion.identity) as GameObject;
                        go.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
                    }
                    else
                    {
                        GameObject go = Instantiate(Cube, new Vector3(0, 0 + offset, i * 1.0f), Quaternion.identity) as GameObject;
                        go.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
                    }
                }
                if(j==x && offset == x)
                {
                    spotLight = new Vector3(0, x, (x-1));
                }
                offset++;
            }
            offset = 1;
            for (int j = 1; j < x + 1; j++)
            {
                for (int i = 0; i < x; i++)
                {
                    GameObject go = Instantiate(Cube, new Vector3(i * 1.0f, 0 + offset, 0), Quaternion.identity) as GameObject;
                    go.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
                }
                offset++;
            }
            offset = 1;
            int t = x - 1;
            for (int h = t; h != 0; h--)
            {
                for (int j = 1; j < x + 1; j++)
                {
                    for (int i = 1; i < x; i++)
                    {
                        if ((h == x / 2) && (offset == 1) && (i == x / 2))//kentro epipedou 1---->magenta
                        {
                            GameObject go = Instantiate(Cube, new Vector3(h * 1.0f, 0 + offset, i * 1.0f), Quaternion.identity) as GameObject;
                            go.GetComponent<MeshRenderer>().material.color = Color.magenta;
                        }
                        else if ((h == x / 2) && (offset == 2) && (i == x / 2)) //kentro epipedou 2
                        {
                            a = new Vector3(h * 1.0f, offset, i * 1.0f);//to kratame gia na xeroume apo poy jekinaei o paixths mas
                        }
                        else
                        {
                            GameObject go = Instantiate(Cube, new Vector3(h * 1.0f, 0 + offset, i * 1.0f), Quaternion.identity) as GameObject;
                            go.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
                        }
                        if (i == 1 && offset == x && h == (x - 1))
                        {
                            spotLight1 = new Vector3(h, x, (i-1));
                        }
                    }
                    offset++;
                }
                offset = 1;
            }
            e = 1;
        }
        if (restart)
        {
            Application.Quit();
           // if (Input.GetKeyDown(KeyCode.R))
           // {
                
           //     Application.LoadLevel(Application.loadedLevel);
           // }
        }
    }
    public void AddScore(int newScoreValue)
    {
        if(newScoreValue == 100)
        {
            score += 100;
            UpdateScore();
            lifes++;
            UpdateLifes();
        }
		else if(newScoreValue==-10){
			score+=10;
			UpdateScore();
		}
        else
        {
            score -= newScoreValue;
            if (score <= 0)
            {
                //lifes--;
                AddLifes();
                //UpdateLifes();
            }
            else
            {
                UpdateScore();
            }
        }
    }

  /*  public void GameOver()
    {
        lifes = 4;
        // Respawn();
        Start();
        gameOverText.text = "Game Over";
        gameOver = true;
    }
*/
    public void AddLifes()
    {
        lifes=lifes-1;
        UpdateLifes();
		if(lifes==0){
            UnityEditor.EditorApplication.isPlaying = false;
            //GameOver();
            restartText.text = "Press R for restart";
            restart = true;
		}else if (lifes > 0)
        {
            score = 100;
            UpdateScore();
        }
    }

    void UpdateScore()
    {
        mText.text = "Score: " + score;
    }

    void UpdateLifes()
    {
        m1Text.text = "Lifes: " + lifes;
    }


    public Vector3 spot
    {
        get
        {
            return spotLight;
        }
    }
    public Vector3 spot1
    {
        get
        {
            return spotLight1;
        }
    }
    public int E//gia ta waitUntil
    {
        get
        {
            return e;
        }
    }
    public Vector3 X1 {//gia thn thesh tou player
        get
        {
            return a;
        }
    }
    public int X//gia to megethos tou perivalontos mas
    {
        get
        {
            return x;
        }
    }
}
