using static Rewards;

public class YellowField
{
    private int[,] values = new int[,]
    {
        { 3, 6, 5, 0 },
        { 2, 1, 0, 5 },
        { 1, 0, 2, 4 },
        { 0, 3, 4, 6 }
    };

    private Reward[] rowRewards = new Reward[]
    {
        new NoReward(),
        new BlueCrossReward(),
        new NoReward(),
        new FoxReward()
    }; // row rewards

    private Reward[] colRewards = new Reward[]
    {
        new TenPointsReward(),
        new FourteenPointsReward(),
        new SixteenPointsReward(),
        new TwentyPointsReward()
    }; // column rewards

    private Reward diagonalReward = new PlusOneReward(); // diagonal reward

    private bool[,] entered = new bool[4, 4]; // tracks which fields have been entered

    public bool CanEnterValue(int dieValue, int row, int col)
    {
        if (row < 0 || row >= 4 || col < 0 || col >= 4)
        {
            return false; // invalid row or column
        }

        if (entered[row, col])
        {
            return false; // field has already been entered
        }

        if (values[row, col] == 0)
        {
            return false; // zero value indicates already entered field
        }

        if (dieValue != values[row, col] && dieValue != 0)
        {
            return false; // die value does not match field value or is not wildcard
        }

        return true;
    }

    public bool EnterValue(int dieValue, int row, int col)
    {
        if (!CanEnterValue(dieValue, row, col))
        {
            return false; // cannot enter value
        }

        entered[row, col] = true;
        Reward reward = null;

        // check for completed row or column
        bool rowCompleted = true;
        bool colCompleted = true;

        for (int i = 0; i < 4; i++)
        {
            if (!entered[row, i])
            {
                rowCompleted = false;
            }

            if (!entered[i, col])
            {
                colCompleted = false;
            }
        }

        if (rowCompleted)
        {
            reward = rowRewards[row]; // set reward if row is completed
        }

        if (colCompleted)
        {
            reward = colRewards[col]; // set reward if column is completed
        }

        // check for completed diagonal
        if (entered[0, 0] && entered[1, 1] && entered[2, 2] && entered[3, 3])
        {
            reward = diagonalReward; // set reward if diagonal is completed
        }

        if (reward != null)
        {
            reward.Activate(this); // apply reward if there is one
        }

        return true; // value entered successfully, but no reward earned
    }

    public int GetValue(int row, int col)
    {
        return values[row, col];
    }

    public bool IsEntered(int row, int col)
    {
        return entered[row, col];
    }
}
