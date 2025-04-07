using UnityEngine;

public class ManagerGeneric : Singleton<ManagerGeneric>
{
    private int _score = 5;
    public int Score { get { return _score; } }

    public void AddScore(int amount)
    {
        _score += amount;
    }
}
