﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chefao : MonoBehaviour
{
    public int vida = 100;
    public GameObject coin;
    public Transform Criarcoin;
    public GameObject ponto11, ponto22;
    private Vector2 nextPos;
    public int danochefao = 10;
    int vidaatual;
    int dano;
    public bool ladoDireito = true;
    // Start is called before the first frame update
    void Start()
    {
        dano = PlayerPrefs.GetInt("dano");
        nextPos = ponto22.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        vidaatual = PlayerPrefs.GetInt("vida");
        movingPlataforma();
        if (vida <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(coin, Criarcoin.position, Criarcoin.rotation);
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tiro"))
        {
            vida -= dano;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("vida", vidaatual-danochefao);

        }
    }
    private void movingPlataforma()
    {

        if (transform.position == ponto11.transform.position)
        {
            nextPos = ponto22.transform.position;
            Vire();
        }
        if (transform.position == ponto22.transform.position)
        {
            nextPos = ponto11.transform.position;
            Vire();

        }
        transform.position = Vector2.MoveTowards(transform.position, nextPos, 3f * Time.deltaTime);
    }
    void Vire()
    {
        ladoDireito = !ladoDireito;

        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        transform.localScale = novoScale;
    }
}