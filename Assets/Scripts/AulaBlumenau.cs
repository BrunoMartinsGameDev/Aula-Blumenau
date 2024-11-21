using System.Collections.Generic;
using UnityEngine;

public class AulaBlumenau : MonoBehaviour
{
    void Start()
    {
        Animal animal1 = new Animal();
        Animal animal2 = new Animal();

        animal1.nome = "Gato";
        animal2.nome = "Cachorro";

        animal1.Dormir();
        animal2.Comer("Ração");


        string palavra = Animal.estatico;
        Animal.MetodoEstatico();


        Mamifero mamifero = new Mamifero();
        AnimalCome(mamifero);
        Ave ave= new Ave();
        AnimalCome(ave);
    }

    void AnimalCome(Animal animal){
        animal.Comer("batata");
    }
}
