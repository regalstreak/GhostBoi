using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchPosition : MonoBehaviour
{
    public Text m_Text;
    public Text m_Text2;

    void Update()
    {

        Touch touch = Input.GetTouch(0);

        //Update the Text on the screen depending on current position of the touch each frame
        m_Text.text = Screen.height.ToString();
        m_Text2.text = "Touch Position : " + touch.position;
    }
}