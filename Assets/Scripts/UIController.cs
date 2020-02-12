using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Canvas main;
    public Canvas menu;

    private void Awake()
    {
        main.enabled = true;
        menu.enabled = false;
    }

    public void OnOpenMenu()
    {
        menu.enabled = true;
        main.enabled = false;
    }

    public void OnCancel()
    {
        main.enabled = true;
        menu.enabled = false;
    }

    public void OnChange()
    {
        main.enabled = true;
        menu.enabled = false;
    }
}
