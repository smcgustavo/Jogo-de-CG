using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int life;
    public Text life_text;

    // Start is called before the first frame update
    void Start()
    {
        life = 100;
    }

    // Update is called once per frame
    void Update()
    {
        atualiza_vida();
    }

    public void atualiza_vida()
    {
        life_text.text = life.ToString();
    }

    public static void recebe_dano(int valor)
    {
        life -= valor;
    }
}
