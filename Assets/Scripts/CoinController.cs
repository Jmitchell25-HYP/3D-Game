using UnityEditor;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;

    public int currentCoin;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        Addcoin(0);
    }

    public void Addcoin(int coinAmount)
    {
        currentCoin += coinAmount;
        //
    }


}
