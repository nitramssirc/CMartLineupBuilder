namespace Common.Enums
{
    public enum Sport
    {
        NFL,
        NBA,
        MLB,
        NHL,
        NCAAF,
        NCAAB
    }

    /// <summary>
    /// Attribute to specify which sports an enum value is associated with
    /// </summary>
    public class WhichSportAttribute : Attribute 
    {
        public WhichSportAttribute(Sport[] sports)
        {
            Sports = sports;
        }

        public Sport[] Sports { get; }
    }
}
