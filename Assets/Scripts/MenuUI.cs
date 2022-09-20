using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject nameInputField;

    public void StartGame()
    {
        MainManager1.Instance.playerName = nameInputField.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene(1);
    }
}
