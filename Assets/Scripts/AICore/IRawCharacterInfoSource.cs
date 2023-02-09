namespace BehaviourModel
{
    /// <summary>
    /// The interface indicates that the class contains raw int values for initializing the character system.
    /// By convention, property values should be in the range(inclusive[1;10] inclusive).
    /// </summary>
    public interface IRawCharacterInfoSource
    {
        public int CalmnessAnxiety{ get; set; }
        public int ClosenessSociability { get; set; }
        public int ConformismNonconformism { get; set; }
        public int ConservatismRadicalism { get; set; }
        public int CredulitySuspicion { get; set; }
        public int EmotionalInstabilityStability { get; set; }
        public int Intelligence { get; set; }
        public int NormativityOfBehaviour { get; set; }
        public int PracticalityDreaminess { get; set; }
        public int RelaxationTension { get; set; }
        public int RestraintExpressiveness { get; set; }
        public int RigiditySensetivity { get; set; }
        public int Selfcontrol { get; set; }
        public int StraightforwardnessDiplomacy { get; set; }
        public int SubordinationDomination { get; set; }
        public int TimidityCourage { get; set; }
    }
}