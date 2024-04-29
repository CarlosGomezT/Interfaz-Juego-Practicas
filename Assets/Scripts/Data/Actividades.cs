using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actividades
{
    public int id; 
    public float tiempoRecord;
    public bool terminado;
    public Actividades()
    {
        id = 0;
        tiempoRecord = 0;
        terminado = false;
    }
    public Actividades(int actividad)
    {
        id = actividad;
        tiempoRecord = 0;
        terminado = false;
    }
}
