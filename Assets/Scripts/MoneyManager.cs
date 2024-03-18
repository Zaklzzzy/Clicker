using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{//добавить Range
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _money;

    [Header("Stats")]
    public uint costPerClick;
    public uint moneyCount;

    [Header("Buttons")]
    [SerializeField] private ButtonScripts[] _buttons;
    [SerializeField] private uint[] _costs;
    [SerializeField] private uint[] _costPerClicks;

    private void Start()
    {
        for(int i = 0; i<_buttons.Length; i++)
        {
            _buttons[i].SetButtonStats(_costs[i], _costPerClicks[i]);
        }
    }
    public void BuyUpgrage(uint cost, uint upgrade)
    {
        moneyCount -= cost;
        ChangeMoney(moneyCount, _money);
        costPerClick += upgrade;
    }
    public void Click() //Для ClickZone
    {
        moneyCount += costPerClick;
        ChangeMoney(moneyCount, _money);
    }

    private void ChangeMoney(uint number, TextMeshProUGUI text) //Буквы у числа
    {
        if(number < 1000)
        {
            text.text = moneyCount.ToString();
        }
        else if (number < 1000000)
        {
            text.text = ((float)moneyCount / 1000).ToString() + "K";
        }
        //else if (moneyCount < 1000000000)
        else
        {
            text.text = ((float)moneyCount / 1000000).ToString() + "M";
        }
    }
}
