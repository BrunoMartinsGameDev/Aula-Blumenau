using UnityEngine;

public class Animal : MonoBehaviour 
{
    //Atributos(Caracteristicas)
    public string nome;
    public char genero;
    public string cor;
    public int vida;
    //Qualquer arquivo pode acessar
    public string publica = "Publico";
    //Apenas a classe e seus filhos pode acessar
    protected string protegida = "Protegido";
    //Apenas a classe pode acessar
    private string privada = "Privado";

    public static string estatico = "Estatico";
    public static void MetodoEstatico(){}    

    public Animal(){
        this.nome = "Gato";
        this.cor = "Cinza";
        this.genero = 'M';
        this.vida = 10;
    }
    public Animal (string nome, char genero, string cor, int vida){
        this.nome = nome;
        this.genero = genero;
        this.cor = cor;
        this.vida = vida;
    }


    //Metodos(Ações)
    //Função sem retorno, sem parâmetros
    public void Dormir(){}
    //Função sem retorno, com parâmetros
    public void Comer(string alimento){}
    //Função com retorno, sem parâmetros
    public string Vida(){
        return this.vida.ToString();
    }
    //Função com retorno, com parâmetros
    public int Vida(string alimento){
        vida+=3;
        return this.vida;
    }
}
public class Mamifero:Animal{
    public string pelagem;
    public int numeroDeMamas;
}
public class Ave:Animal, IAve{
    public string corBico;
    public float envergadura;

    private float tamanhoDoOvo;
    public float TamanhoDoOvo{
        get{return this.tamanhoDoOvo;}
        set{this.tamanhoDoOvo = value;}
    }
    public string Dieta {get; set;}

    public void Voo()
    {
        throw new System.NotImplementedException();
    }
}
public interface IAve{
    void Voo();
}