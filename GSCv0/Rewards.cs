internal class Rewards
{
    public abstract class Reward
    {
        public abstract void Activate(YellowField yellowField);
    }

    public class NoReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // No specific action for this reward
        }
    }

    public class BlueCrossReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            yellowField.EnterBlueField();
        }
    }

    public class FoxReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            int min = int.MaxValue;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (yellowField.IsEntered(row, col))
                    {
                        int value = yellowField.GetValue(row, col);
                        if (value > 0 && value < min)
                        {
                            min = value;
                        }
                    }
                }
            }

            // Add points to player
            // player.AddPoints(min);
        }
    }

    public class PlusOneReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate PlusOneReward
        }
    }

    public class TenPointsReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate TenPointsReward
        }
    }

    public class FourteenPointsReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate FourteenPointsReward
        }
    }

    public class SixteenPointsReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate SixteenPointsReward
        }
    }

    public class TwentyPointsReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate TwentyPointsReward
        }
    }

    public class OrangeFiveReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate OrangeFiveReward
        }
    }

    public class YellowCrossReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate YellowCrossReward
        }
    }

    public class PurpleSixReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate PurpleSixReward
        }
    }

    public class RerollReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate RerollReward
        }
    }

    public class OrangeSixReward : Reward
    {
        public override void Activate(YellowField yellowField)
        {
            // Add the logic to activate OrangeSixReward
        }
    }
}
