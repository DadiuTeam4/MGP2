//Author: You Wu
//Contributor:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CookieJarEventNotifier : MonoBehaviour
{
    private Text number2Text;
    private int number2Count;
    // Use this for initialization
    void Start()
    {
        EventManager.StartListening(EventName.CookieJarTouched, AddNumber2);
        number2Text = gameObject.GetComponent<Text>();
        number2Count = 0;
    }

    private void AddNumber2()
    {
        Debug.Log("Add a Number 2");
        number2Count++;
        number2Text.text = "You have " + number2Count + " Number 2";
    }
}
