using TMPro;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{
    [Header("Button Stats")]
    [SerializeField] private uint _costUpgrade;
    [SerializeField] private uint _costPerClick;
    [SerializeField] private TextMeshProUGUI _costText;
    
    [Header("Manager")]
    [SerializeField] private MoneyManager _manager;

    public void SetButtonStats(uint savedCost, uint savedCostPerClick)
    {
        _costUpgrade = savedCost;
        _costPerClick = savedCostPerClick;
        _costText.text = _costUpgrade.ToString();
    }
    public void BuyButton()
    {
        if (_costUpgrade <= _manager.moneyCount)
        {
            _manager.BuyUpgrage(_costUpgrade, _costPerClick);

            _costUpgrade = _costUpgrade + 100; //временные значения, нужно просчитать и поменять
            _costText.text = _costUpgrade.ToString();
            
            _costPerClick += _costPerClick + 1; //временные значения, нужно просчитать и поменять
        } 
    }
}