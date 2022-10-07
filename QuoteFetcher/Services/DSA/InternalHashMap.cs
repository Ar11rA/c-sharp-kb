using QuoteFetcher.DTO;

namespace QuoteFetcher.Services.DSA;

public class InternalHashMap
{
    private const int PRIME_MULTIPLIER = 61;
    private int size;
    private int capacity;
    private HMNode?[] nodes;

    public InternalHashMap()
    {
        size = 0;
        capacity = 5;
        nodes = new HMNode?[capacity];
        for (int i = 0; i < capacity; i++)
        {
            nodes[i] = null;
        }
    }

    private int calculateHash(int key)
    {
        int ctr = 0, hash = 0;
        while (key > 0)
        {
            hash += (int) System.Math.Pow(PRIME_MULTIPLIER, ctr);
            key /= 10;
            ctr++;
        }

        return hash % capacity;
    }

    private void reHash()
    {
        HMNode?[] previousNodes = nodes;
        capacity *= 2;
        nodes = new HMNode[capacity];
        for (int i = 0; i < capacity; i++)
        {
            nodes[i] = null;
        }

        size = 0;
        foreach (HMNode node in previousNodes)
        {
            HMNode temp = node;
            while (temp != null)
            {
                Put(temp.Key, temp.Value);
                temp = temp.Next;
            }
        }
    }

    public void Put(int key, int value)
    {
        if ((double) size / capacity > 0.7)
        {
            reHash();
        }

        int hash = calculateHash(key);
        if (nodes[hash] == null)
        {
            HMNode tmp = new()
            {
                Key = key,
                Value = value,
                Next = null
            };
            nodes[hash] = tmp;
        }
        else
        {
            HMNode curr = nodes[hash];
            while (curr.Next != null)
            {
                if (curr.Key == key)
                {
                    curr.Value = value;
                    return;
                }

                curr = curr.Next;
            }

            HMNode tmp = new()
            {
                Key = key,
                Value = value,
                Next = null
            };
            curr.Next = tmp;
        }

        size++;
    }

    public int Get(int key)
    {
        int hash = calculateHash(key);
        HMNode? temp = nodes[hash];
        while (temp != null)
        {
            if (temp.Key == key)
            {
                return temp.Value;
            }

            temp = temp.Next;
        }

        return -1;
    }
}
