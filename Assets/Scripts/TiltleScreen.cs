using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TiltleScreen : MonoBehaviour
{
    [SerializeField] public Image screen;
    // Start is called before the first frame update
    void Start()
    {
        screen.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width+100);
        screen.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height + 100);

    }

    public void WhenClicked()
    {
        SceneManager.LoadScene(1);
    }
}
