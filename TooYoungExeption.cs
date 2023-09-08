namespace hwLesson16
{
    public class TooYoungExeption : Exception
    {
        public byte Age { get; }

        public TooYoungExeption(byte age) : base("Candidate is too young.")
        {
            Age = age;
        }
    }
}