using UnityEngine;
using TMPro;
using System.Collections;

public class NotificationUI : MonoBehaviour
{
    public static NotificationUI instance;
    public TextMeshProUGUI notificationText;
    public float displayTime = 2f; // how long the message shows

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        notificationText.text = ""; // start empty
    }

    public void ShowMessage(string message)
    {
        StopAllCoroutines(); // stop any current message
        StartCoroutine(DisplayMessage(message));
    }

    IEnumerator DisplayMessage(string message)
    {
        notificationText.text = message;
        yield return new WaitForSeconds(displayTime);
        notificationText.text = ""; // clear after displayTime
    }
}