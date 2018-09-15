using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MessageDialogController : MonoBehaviour
{
    public Button btnClose;
    public Text title;
    public Text content;

    public MessageDialogController()
    {

    }

    public void fillDialogInfo(string title, string content)
    {
        this.title.text = title;
        this.content.text = content;
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void btnCloseOnClick()
    {
        gameObject.SetActive(false);
    }
}