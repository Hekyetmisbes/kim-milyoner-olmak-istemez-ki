using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] timer = new GameObject[14];

    private MenuScript menuScript;

    private float lastSecond = 0f;
    private bool isTimerActive = false; // Ba�lang��ta timer pasif olsun
    private float currentTimeStart = 0;
    private float currentTime = 0;
    private int currentSecond;

    private bool isMenuOpen;

    // Start is called before the first frame update
    void Start()
    {
        isMenuOpen = false;
        // Timer'� ba�latmak i�in burada de�il, ba�lang��ta men� aktif oldu�u i�in Start fonksiyonunu kullanm�yoruz
    }

    // Update is called once per frame
    void Update()
    {
        // Men� a��k de�ilse timer �al��s�n
        if (!isMenuOpen)
        {
            currentTimeStart = Time.time;
            if (currentTimeStart > 1)
            {
                if (isTimerActive)
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
                        isTimerActive = false;
                        currentTimeStart = 0;
                        currentSecond = 0;
                        currentTime = 0;
                        Debug.Log("Oyun bitti");
                    }
                }
            }
        }
    }

    // Men�y� a��k duruma getir
    public void OpenMenu()
    {
        isMenuOpen = true;
        SceneManager.LoadScene("MainMenu");
    }

    // Timer'� s�f�rla
    public void ResetTimer()
    {
        // Timer'� ba�lat
        isTimerActive = true;
        currentTimeStart = Time.time;
        currentTime = Time.time;
        currentSecond = 0;

        // T�m timer'lar� aktif hale getir
        foreach (GameObject obj in timer)
        {
            obj.SetActive(true);
        }
    }
}
