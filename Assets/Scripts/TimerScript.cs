using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    GameObject timer13;
    [SerializeField]
    GameObject timer12;
    [SerializeField]
    GameObject timer11;
    [SerializeField]
    GameObject timer10;
    [SerializeField]
    GameObject timer9;
    [SerializeField]
    GameObject timer8;
    [SerializeField]
    GameObject timer7;
    [SerializeField]
    GameObject timer6;
    [SerializeField]
    GameObject timer5;
    [SerializeField]
    GameObject timer4;
    [SerializeField]
    GameObject timer3;
    [SerializeField]
    GameObject timer2;
    [SerializeField]
    GameObject timer1;
    [SerializeField]
    GameObject timer0;


    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        startTime = Time.time;
        int i = (int)startTime;
        if (startTime == i)
        {
            GameObject.Find("timer" + i).GetComponent<Image>().Equals("Bos");
        }
        Debug.Log(((int)startTime));
    }
}
