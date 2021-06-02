namespace MVVM
{
    public class BonusViewModel : IBonusViewModel
    {
        public IBonusModel BonusModel { get; }

        public BonusViewModel(IBonusModel bonusModel)
        {
            BonusModel = bonusModel;
        }

    }
}