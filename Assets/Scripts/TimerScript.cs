using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    GameObject[] timer = new GameObject[14];

    private MenuScript menuScript;

    private float lastSecond = 0f;
    private bool isTimerActive = false; // Baþlangýçta timer pasif olsun
    private float currentTimeStart = 0;
    private float currentTime = 0;
    private int currentSecond;

    private bool isMenuOpen;

    // Start is called before the first frame update
    void Start()
    {
        isMenuOpen = false;
        // Timer'ý baþlatmak için burada deðil, baþlangýçta menü aktif olduðu için Start fonksiyonunu kullanmýyoruz
    }

    // Update is called once per frame
    void Update()
    {
        // Menü açýk deðilse timer çalýþsýn
        if (!isMenuOpen)
        {
            currentTimeStart = Time.time;
            if (currentTimeStart > 1)
            {
                if (isTimerActive)
                {
                    currentTime = Time.time;
                    currentSecond = Mathf.FloorToInt(currentTime); // Geçen zamaný tam sayýya yuvarla

                    // Eðer geçen saniye son saniyeden farklýysa, bir saniye geçmiþtir
                    if (currentSecond != lastSecond)
                    {
                        lastSecond = currentSecond; // Son saniyeyi güncelle

                        // Her saniye bir timer nesnesini devre dýþý býrak
                        for (int j = 0; j < 14; j++)
                        {
                            timer[currentSecond - 1].SetActive(false);
                        }
                    }

                    Debug.Log(currentSecond); // Güncel saniyeyi logla

                    // Eðer geçen saniye 14 ise, oyunu bitir
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

    // Menüyü açýk duruma getir
    public void OpenMenu()
    {
        isMenuOpen = true;
        SceneManager.LoadScene("MainMenu");
    }

    // Timer'ý sýfýrla
    public void ResetTimer()
    {
        // Timer'ý baþlat
        isTimerActive = true;
        currentTimeStart = Time.time;
        currentTime = Time.time;
        currentSecond = 0;

        // Tüm timer'larý aktif hale getir
        foreach (GameObject obj in timer)
        {
            obj.SetActive(true);
        }
    }
}
