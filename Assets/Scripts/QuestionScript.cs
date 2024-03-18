using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;


public class QuestionScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI soruMetniText;
    [SerializeField]

    TextMeshProUGUI secenekAText;
    [SerializeField]
    TextMeshProUGUI secenekBText;
    [SerializeField]
    TextMeshProUGUI secenekCText;
    [SerializeField]
    TextMeshProUGUI secenekDText;

    [SerializeField]
    Button secenekAButton;
    [SerializeField]
    Button secenekBButton;
    [SerializeField]
    Button secenekCButton;
    [SerializeField]
    Button secenekDButton;

    private string connectionString = "URI=file:" + Application.dataPath + "/Plugins/sorular.db";

    private string dogruCevap;

    private int soruSayisi = 0;

    void Start()
    {
        LoadQuestion();
    }

    void LoadQuestion()
    {
        using (var dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            // Rastgele bir soru se�
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Sorular ORDER BY RANDOM() LIMIT 1"; // Rastgele bir soru se�me
                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        soruMetniText.text = reader.GetString(1); // 2. s�tun: soru metni
                        secenekAText.text = reader.GetString(2); // 3. s�tun: se�enek A
                        secenekBText.text = reader.GetString(3); // 4. s�tun: se�enek B
                        secenekCText.text = reader.GetString(4); // 5. s�tun: se�enek C
                        secenekDText.text = reader.GetString(5); // 6. s�tun: se�enek D
                        dogruCevap = reader.GetString(6); // 7. s�tun: do�ru cevap
                    }
                }
            }

            dbConnection.Close();
        }

        secenekAButton.onClick.AddListener(() => CheckAnswer(secenekAText.text));
        secenekBButton.onClick.AddListener(() => CheckAnswer(secenekBText.text));
        secenekCButton.onClick.AddListener(() => CheckAnswer(secenekCText.text));
        secenekDButton.onClick.AddListener(() => CheckAnswer(secenekDText.text));
    }

    public void CheckAnswer(string secilenCevap)
    {
        // Kullan�c�n�n cevab�n� do�ru cevapla kar��la�t�r
        if (secilenCevap == dogruCevap)
        {
            Debug.Log("Do�ru cevap!");
        }
        else
        {
            Debug.Log("Yanl�� cevap! Do�ru cevap: " + dogruCevap);
        }
        soruSayisi++;
    }
}
