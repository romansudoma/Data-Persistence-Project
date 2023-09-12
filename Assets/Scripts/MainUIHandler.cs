using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIHandler : MonoBehaviour
{
    public void ReturnToMenu()
    {
        GameManager.Instance.ReturnToMenu();
    }
}
