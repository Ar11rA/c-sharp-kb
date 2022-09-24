namespace QuoteFetcher.Services.OOPS;

using System;
public class AtmMachine
{
    private readonly int[] _balanceNotes;
    private readonly int[] _possibleDenominations;

    public AtmMachine()
    {
        _balanceNotes = new[] {0, 0, 0, 0, 0};
        _possibleDenominations = new[] {500, 200, 100, 50, 20};
    }

    public void Deposit(int[] banknotesCount)
    {
        for (int index = 0; index < banknotesCount.Length; index++)
        {
            _balanceNotes[index] += banknotesCount[index];
        }
    }

    public int[] Withdraw(int amount)
    {
        int[] tempArray = {0, 0, 0, 0, 0};
        for (int index = 0; index < _possibleDenominations.Length; index++)
        {
            int number = amount / _possibleDenominations[index];
            int available = Math.Min(_balanceNotes[_balanceNotes.Length - index - 1], number);
            tempArray[_balanceNotes.Length - index - 1] = available;
            amount -= (available * _possibleDenominations[index]);
            if (amount != 0)
            {
                continue;
            }

            for (int j = 0; j < _balanceNotes.Length; j++)
            {
                _balanceNotes[j] -= tempArray[j];
            }

            break;
        }

        return amount != 0 ? new[] {-1} : tempArray;
    }
}
