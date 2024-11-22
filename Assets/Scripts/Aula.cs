using System;
using UnityEngine;

public class Aula : MonoBehaviour, Imetodos
{
    string nome = "Matheus";
    private void Awake()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World!");
    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (10 > 5 || 10 > 2)
        {
            print("10 é maior que 5 e 10 é maior que 2");
        }
    }
    private void LateUpdate()
    {

    }
    void funcao (Imetodos objeto){
        objeto.levantar();
    }

    public void levantar()
    {
        throw new NotImplementedException();
    }
}
interface Imetodos{
    void levantar();
}