using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataItem : MonoBehaviour
{
    
    public Sprite selada, daunBawang, bayamMerah, seledri, netPot, Penyiram, obat, semprotan;
    public GameObject itemImage;
    [SerializeField] GameObject menuShop;
    [SerializeField] GameObject menuBag;
    [SerializeField] GameObject validationButton;
    static int money;
    static int costItem;
    [SerializeField] Text moneyText;
    [SerializeField] Text moneyTextBack;
    [SerializeField] Text ValidText;
    [SerializeField] Image titleValid;
    [SerializeField] GameObject validYes;
    [SerializeField] GameObject validNo;
    [SerializeField] GameObject validConfirm;
    static int seedSelada, seedBawang, seedBayam, seedSeledri, totalObat,totalPot;
    [SerializeField] Text countSelada, countBawang, countBayam, countSeledri, countObat, countPot;

    void Start()
    {
        money = 0;
        seedSeledri = 0;
        seedSelada = 0;
        seedBayam = 0;
        seedBawang = 0;
        totalPot = 0;
        totalObat = 0;

    }

    public void buySelada()
    {
        costItem = 3000;
        itemImage.GetComponent<Image>().sprite = selada;
        seedSelada += 1;
        changePage();
       

    }

    public void buyDaunBawang()
    {
        costItem = 3000;
        itemImage.GetComponent<Image>().sprite = daunBawang;
        seedBawang += 1;
        changePage();

    }

    public void buyBayamMerah()
    {
        costItem = 3000;
        itemImage.GetComponent<Image>().sprite = bayamMerah;
        seedBayam += 1;
        changePage();

    }

    public void buySeledri()
    {
        costItem = 3000;
        itemImage.GetComponent<Image>().sprite = seledri;
        seedSeledri += 1;
        changePage();

    }

    public void buyNetpot()
    {
        costItem = 6000;
        itemImage.GetComponent<Image>().sprite = netPot;
        totalPot += 1;
        changePage();

    }

    public void buyObat()
    {
        costItem = 18000;
        itemImage.GetComponent<Image>().sprite = obat;
        totalObat += 1;
        changePage();
        

    }

    public void validasiBeli()
    {
        checkMoney();
    }

    public void confirmCheck()
    {
        menuShop.gameObject.SetActive(true);
        menuBag.gameObject.SetActive(false);
        validationButton.gameObject.SetActive(false);
        validNo.gameObject.SetActive(false);
        validYes.gameObject.SetActive(false);
        validConfirm.gameObject.SetActive(false);
    }

    void checkMoney()
    {
        if (money <= costItem)
        {
            ValidText.GetComponent<Text>().text = "Maaf, koin yang anda miliki kurang untuk membeli barang ini";
            titleValid.GetComponent<Image>().color = Color.red;
            ValidText.fontSize = 14;
            validNo.gameObject.SetActive(false);
            validYes.gameObject.SetActive(false);
            validConfirm.gameObject.SetActive(true);
        }
        else if(money > costItem)
        {
            money -= costItem;
            ValidText.GetComponent<Text>().text = "Barang berhasil anda beli, harap check di menu bag!";
            titleValid.GetComponent<Image>().color = Color.green;
            ValidText.fontSize = 14;
            validNo.gameObject.SetActive(false);
            validYes.gameObject.SetActive(false);
            validConfirm.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        moneyText.GetComponent<Text>().text = money.ToString();
        moneyTextBack.GetComponent<Text>().text = money.ToString();
        countBawang.GetComponent<Text>().text = seedBawang.ToString();
        countBayam.GetComponent<Text>().text = seedBayam.ToString();
        countSelada.GetComponent<Text>().text = seedSelada.ToString();
        countSeledri.GetComponent<Text>().text = seedSeledri.ToString();
        countObat.GetComponent<Text>().text = totalObat.ToString();
        countPot.GetComponent<Text>().text = totalPot.ToString();
    }


    void changePage()
    {
        menuShop.gameObject.SetActive(false);
        menuBag.gameObject.SetActive(false);
        validationButton.gameObject.SetActive(true);
        validNo.gameObject.SetActive(true);
        validYes.gameObject.SetActive(true);
        validConfirm.gameObject.SetActive(false);
        shopStart();
    }


    void shopStart()
    {
        ValidText.GetComponent<Text>().text = "Apakah anda yakin membeli barang ini?";
        titleValid.GetComponent<Image>().color = Color.black;
        ValidText.GetComponent<Text>().fontSize = 16;
    }

    public void addCoin()
    {
        money += 1000;
    }

    public void removeCoin()
    {
        money -= 1000;
    }






}
