using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class Islemler : MonoBehaviour
{
    public GameObject knife,elma,trap;
    public Transform spawnpoint;
    public bool gameover;
    public GameObject[] noktalar;
    public int stage;
    public int hedef, atilandogrubicak,toplam;
    public TMP_Text knifenumbertext,stagetext;
    public GameObject icon, iconpanel,gameoverpanel,ingame;
    GameObject[] icons;
    public int qq=0;


   



    void Start()
    {
        gameoverpanel.SetActive(false) ;
        ingame.SetActive(true);
        stage = PlayerPrefs.GetInt("level",1);
        toplam = PlayerPrefs.GetInt("toplam");
        knifenumbertext.text = PlayerPrefs.GetInt("toplam").ToString();

        stagetext.text = "Stage " + stage;
        ObjeSpawn();
        Control();
        IconMake();
    }


    void Update()
    {
        if (gameover == true)
        {
            gameoverpanel.SetActive(true);
            ingame.SetActive(false);
            GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text ="Score       " + toplam.ToString();
            
        }
        else
        {
            NextStage();
        }
    }

    public void GameOver()
    {
        PlayerPrefs.DeleteAll(); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }



    void IconMake()
    {
        icons = new GameObject[hedef];
        for (int i = 0; i < hedef; i++)
        {
            GameObject g = Instantiate(icon, iconpanel.transform);
            g.transform.SetParent(iconpanel.transform);
            icons[i] = g;
        }
    }

 


    void Control()
    {
        int a = PlayerPrefs.GetInt("level");
        if (a==1)
        {
            hedef = 4;
        }
        else if (a==2)
        {
            hedef = 5;
        }
        else if (a == 3)
        {
            hedef = 6;
        }
        else if (a == 4)
        {
            hedef = 7;
        }
    }


    void NextStage()
    {
        if (atilandogrubicak==hedef)
        {
            stage++;
            PlayerPrefs.SetInt("level",stage);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Spawn()
    {
        if (gameover==false)
        {
            
            GameObject g = Instantiate(knife, spawnpoint.transform.position, Quaternion.identity);
            atilandogrubicak++;
            toplam ++;
            PlayerPrefs.SetInt("toplam", toplam);
            knifenumbertext.text = PlayerPrefs.GetInt("toplam").ToString();
            icons[qq].GetComponent<Image>().color = Color.black;
            qq++;
        }
        

    }
    void ObjeSpawn()
    {
        int a = Random.Range(0, 7);
        GameObject g = Instantiate(elma, noktalar[a].transform.position, Quaternion.identity);
        g.transform.SetParent(noktalar[a].transform);
        int b = Random.Range(0, 7);
        if (b!=a)
        {
            GameObject h = Instantiate(trap, noktalar[b].transform.position, Quaternion.identity);
            h.transform.SetParent(noktalar[b].transform);
            if (b==0)
            {
                noktalar[b].transform.Rotate(0,0,180);
            }
            else if (b ==1)
            {
                 noktalar[b].transform.Rotate(0, 0,0);
            }
            if (b == 2)
            {
                noktalar[b].transform.Rotate(0, 0, -80);
            }
            if (b == 3)
            {
                noktalar[b].transform.Rotate(0, 0, 90);
            }
            if (b == 4)
            {
                noktalar[b].transform.Rotate(0, 0, -180);
            }
            if (b == 5)
            {
                noktalar[b].transform.Rotate(0, 0, -180);
            }
            if (b == 6)
            {
                noktalar[b].transform.Rotate(0, 0, 180);
            }
            if (b == 7)
            {
                noktalar[b].transform.Rotate(0, 0, -187);
            }
        }
        else
        {
            b = Random.Range(0, 7);
        }
    }
}
