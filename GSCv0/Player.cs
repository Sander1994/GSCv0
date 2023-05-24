using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

public class Player
{
    private List<int> dice;
    private int[] scoreFields;
    private int points;

    public Player()
    {
        dice = new List<int>();
        scoreFields = new int[12];
        points = 0;
    }

    public void AddDie(int die)
    {
        dice.Add(die);
    }

    public void RemoveDie(int die)
    {
        dice.Remove(die);
    }

    public void RollDice()
    {
        dice.Clear();
        for (int i = 0; i < 6; i++)
        {
            dice.Add(RandomNumberGenerator.GetInt32(1, 7));
        }
    }

    public List<int> GetDice()
    {
        return dice;
    }

    public void EnterBlueField()
    {
        for (int i = 0; i < scoreFields.Length; i++)
        {
            if (scoreFields[i] == 0 && i % 2 == 1)
            {
                scoreFields[i] = -1;
                break;
            }
        }
    }

    public void EnterNextFreeOrangeField(int value)
    {
        for (int i = 0; i < scoreFields.Length; i++)
        {
            if (scoreFields[i] == 0 && i >= 2 && i <= 5)
            {
                scoreFields[i] = value;
                break;
            }
        }
    }

    public void EnterNextFreeGreenField()
    {
        for (int i = 0; i < scoreFields.Length; i++)
        {
            if (scoreFields[i] == 0 && i >= 6 && i <= 8)
            {
                scoreFields[i] = 1;
                break;
            }
        }
    }

    public void EnterNextFreePurpleField(int value)
    {
        for (int i = 0; i < scoreFields.Length; i++)
        {
            if (scoreFields[i] == 0 && i >= 9 && i <= 11)
            {
                scoreFields[i] = value;
                break;
            }
        }
    }

    public void EnterNextFreeYellowField(int value)
    {
        for (int i = 0; i < scoreFields.Length; i++)
        {
            if (scoreFields[i] == 0 && i % 2 == 0)
            {
                scoreFields[i] = value;
                break;
            }
        }
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public int GetPoints()
    {
        return points;
    }

    public int[] GetScoreFields()
    {
        return scoreFields;
    }

    public bool HasField(int value)
    {
        return scoreFields.Contains(value);
    }

    public bool HasOrangeFields()
    {
        for (int i = 2; i <= 5; i++)
        {
            if (scoreFields[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool HasAllFields()
    {
        for (int i = 0; i < scoreFields.Length; i++)
        {
            if (scoreFields[i] == 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool HasYellowFields()
    {
        for (int i = 0; i < scoreFields.Length; i += 2)
        {
            if (scoreFields[i] == 0)
            {
                return false;
            }
        }
        return true;
    }



