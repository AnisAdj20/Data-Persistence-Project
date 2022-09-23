using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MenuUiHandler : MonoBehaviour
{
    [SerializeField] private InputField nameField;
    public void StartNew()
    {
        DataPersistence.Instance.nameField = nameField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        EditorApplication.Quit();
#endif
    }

}
