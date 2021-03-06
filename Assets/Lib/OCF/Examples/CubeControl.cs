﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : Controllable
{
    [OSCProperty]
    public int nombreInt;

    [OSCProperty]
    public float nombreFloat;

    [OSCProperty]
    public string myString;

    [OSCProperty]
    public bool rotate;

    [OSCProperty]
    [Range(0, 100)]
    public int IntSlider;

    [OSCProperty]
    [Range(0,100)]
    public float speed;

    [OSCProperty]
    public Vector3 pos;

    [OSCProperty]
    public Color cubeColor;

    [OSCMethod]
    public void setColor(Color col)
    {
        cubeColor = col;
        GetComponent<Renderer>().material.color = cubeColor;
    }

    [OSCMethod]
    public void setColorRed()//Color col)
    {
        setColor(Color.red);//col;
    }

    [OSCMethod]
    public void setColorWhite()//Color col)
    {
        setColor(Color.white);//col;
    }

    public override void Awake()
    {
        usePanel = true;
        debug = false;
        base.Awake();
    }

    // Use this for initialization
    void Start ()
    {
        GetComponent<Renderer>().material.color = cubeColor;
    }

    // Update is called once per frame
    public override void Update ()
    {
         base.Update();
         pos = transform.position;
         if(rotate)
            transform.Rotate(Vector3.up, Time.deltaTime * speed);

         //Debug.Log("Nombre (int) : " + nombreInt);
         //Debug.Log("Nombre (float) : " + nombreFloat);
    }

    public override void DataLoaded()
    {
        setColor(cubeColor);
    }
}
