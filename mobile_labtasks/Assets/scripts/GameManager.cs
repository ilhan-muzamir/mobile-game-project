using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text coin_Text;

    Player_Controller coin_to_Add;
    // Start is called before the first frame update
    void Start()
    {
        coin_to_Add = GameObject.Find("Player").GetComponent<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        coin_Text.text = coin_to_Add.coinsum.ToString();
    }


}
