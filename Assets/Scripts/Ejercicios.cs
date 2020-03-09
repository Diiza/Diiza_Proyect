using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicios : MonoBehaviour
{
    public GameObject Numeros;
    public GameObject Menú;
    public int alfabeto1, numeros1, plantas1, animales1, hogar1, emociones1, familia1, cuerpo1, ropa1, oraciones1;
    public void Update()
    {
        
    }

    public void EjemNumeros()
    {
        AbrirMenu alf = gameObject.GetComponent<AbrirMenu>();
        //alf.GetComponent<AbrirMenu>();
        alfabeto1 = alf.alfabeto;
        Debug.Log("LEER EL DATO");
        Debug.Log(alfabeto1);

        AbrirMenu num = new AbrirMenu();
        num.GetComponent<AbrirMenu>();
        numeros1 = num.numeros;
        Debug.Log("LEER EL DATO");
        Debug.Log(numeros1);

        AbrirMenu plant = GetComponent<AbrirMenu>();
        plantas1 = plant.plantas;
        Debug.Log(plant.plantas);

        AbrirMenu anim = GetComponent<AbrirMenu>();
        animales1 = anim.animales;

        AbrirMenu hog = GetComponent<AbrirMenu>();
        hogar1 = hog.hogar;

        AbrirMenu emoc = GetComponent<AbrirMenu>();
        emociones1 = emoc.emociones;

        AbrirMenu fam = GetComponent<AbrirMenu>();
        familia1 = fam.familia;

        AbrirMenu cuerp = GetComponent<AbrirMenu>();
        cuerpo1 = cuerp.cuerpo;

        AbrirMenu rop = GetComponent<AbrirMenu>();
        ropa1 = rop.ropa;

        AbrirMenu orac = GetComponent<AbrirMenu>();
        oraciones1 = orac.oraciones;

        if (numeros1==1)
        {
            Menú.SetActive(false);
            Numeros.SetActive(true);
        }
    }
}
