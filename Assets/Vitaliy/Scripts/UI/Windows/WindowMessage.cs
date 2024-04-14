using Infrastructure;
using TMPro;
using UnityEngine;

public class WindowMessage : Window
{
    [SerializeField]
    private TMP_Text _titleText; 
    [SerializeField]
    private TMP_Text _messageText;

    public override void Construct(DependencyInjection diContainer)
    { }

    public void SetMassage(string heading, string massage)
    {
        _titleText.text = heading;
        _messageText.text = massage;
    }

    public override void Activate() => 
        gameObject.SetActive(true);

    public override void Close() => 
        gameObject.SetActive(false);
}