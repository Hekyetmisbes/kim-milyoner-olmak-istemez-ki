using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] timer = new GameObject[14];

    private float lastSecond = 0f;
    private float currentTimeStart = 0;
    private float currentTime = 0;
    private int currentSecond;

    private bool timerActive;

    //write onsceneload method
    public void OnSceneLoad()
    {
        RestartTimer();
    }

    // Start is called before the first frame update
    void Start()
    {
        RestartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTimeStart = Time.time;
            if (currentTimeStart > 1)
            {
                currentTime = Time.time;
                currentSecond = Mathf.FloorToInt(currentTime); // Ge�en zaman� tam say�ya yuvarla

                // E�er ge�en saniye son saniyeden farkl�ysa, bir saniye ge�mi�tir
                if (currentSecond != lastSecond)
                {
                    lastSecond = currentSecond; // Son saniyeyi g�ncelle

                    // Her saniye bir timer nesnesini devre d��� b�rak
                    for (int j = 0; j < 14; j++)
                    {
                        timer[currentSecond - 1].SetActive(false);
                    }
                }

                Debug.Log(currentSecond); // G�ncel saniyeyi logla

                // E�er ge�en saniye 14 ise, oyunu bitir
                if (currentSecond == 14)
                {
                    timerActive = false;
                    currentTimeStart = 0;
                    currentSecond = 0;
                    currentTime = 0;
                    Debug.Log("Oyun bitti");
                }
            }
        }
    }

    public void RestartTimer()
    {
        timerActive = true;
        currentTimeStart = 0;
        lastSecond = 0f;
        currentSecond = 0;
    }
}
