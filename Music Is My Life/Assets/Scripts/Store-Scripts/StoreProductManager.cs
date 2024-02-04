using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreProductManager : MonoBehaviour
{
    public TMP_Text playerMoney; // 플레이어가 보유 중인 돈
    public GameObject[] allProductObj; // 모든 상품

    
    void Start()
    {
        playerMoney.text = "잔고: " + PlayerPrefs.GetInt("Money") + "만원";
        // 음향기기와 굿즈에 판매할 아이템 종류랑 아이템 남은 개수 넣기
        LoadAllProductsData();
    }

    public void LoadAllProductsData()
    {
        foreach (GameObject productObj in allProductObj)
        {
            StoreProduct product = productObj.GetComponent<StoreProduct>();

            product.LoadFurnitureStatus();
            Debug.Log("상품명: " + product.furnitureName + " | 가격: " + product.price);
            Button button = product.GetComponentInChildren<Button>();
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (product.IsOwned)
            {
                buttonText.text = "구매 완료";
            }
            else
            {
                buttonText.text = "구매하기";
            }
        }
    }
}