namespace QuoteFetcher.Services.OOPS;

public class NumberContainer
{
    private readonly Dictionary<int, int> _indexToNumber;
    private readonly Dictionary<int, SortedSet<int>> _numberToIndices;
    public NumberContainer()
    {
        _indexToNumber = new Dictionary<int, int>();
        _numberToIndices = new Dictionary<int, SortedSet<int>>();
    }
    
    public void Change(int index, int number)
    {
        if (_indexToNumber.TryGetValue(index, out int val)) _numberToIndices[val].Remove(index);
        
        _indexToNumber[index] = number;
        _numberToIndices.TryAdd(number, new SortedSet<int>());
        _numberToIndices[number].Add(index);
    }
    
    public int Find(int number) {
        if (!_numberToIndices.ContainsKey(number))
        {
            return -1;
        }

        int foundIndex = _numberToIndices[number].First();
        _numberToIndices[number].Add(foundIndex);
        return foundIndex;
    }
}
