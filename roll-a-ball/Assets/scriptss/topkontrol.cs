using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class topkontrol : MonoBehaviour
{
    Rigidbody fizik;
    public int hiz;
    int sayac = 0;
    public int Toplan�lacakobjeSayisi;
    public Text sayacText;
    public Text OyunBittiText;
    void Start()
   {
        fizik = GetComponent<Rigidbody>();  
    }
    void Update() //topun ilerleme y�nleri x ve x y�nlerinde hareket edebilir yukar� a�a�� gidemez.
    {
        float yatay = Input.GetAxisRaw("Horizontal");
        float dikey = Input.GetAxisRaw("Vertical");
        Debug.Log("yatay= " + yatay +  "   dikey= "+ dikey);
        Vector3 vec = new Vector3(yatay,0, dikey);
        fizik.AddForce(vec*hiz);
    }
    private void OnTriggerEnter(Collider other)//topumuz engele de�di�inde engeli g�zden kaybetmek
    {
        if (other.gameObject.tag == "engel")
        {
            other.gameObject.SetActive(false);
            sayac++;
            sayacText.text = "Sayac= " + sayac; //engellere de�dik�e puan topluyoruz.
            if(sayac== Toplan�lacakobjeSayisi)
            {
                OyunBittiText.text = "OYUN B�TT� "; //t�m engeller bitti�inde oyun bitti yaz�s�n� ekrana ver.
            }
        }
    }

}
