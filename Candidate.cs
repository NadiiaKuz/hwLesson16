using System.Drawing;

namespace hwLesson16
{
    class Candidate : IComparable
    {
        public string Name { get; }
        public ushort YearOfBirth { get; }
        public double Experience { get; }

        public Candidate(string name, ushort yearOfBirth, double experience)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
            Experience = experience;
        }

        public int CompareTo(object obj)
        {
            if (obj is Candidate)
            {
                Candidate p = (Candidate)obj;

                if ((int)Experience > (int)p.Experience)
                {
                    return 1;
                }
                else if ((int)Experience < (int)p.Experience)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            
            throw new ArgumentException();
        }

        public static bool operator ==(Candidate candidate1, Candidate candidate2)
        {
            return (int)candidate1.Experience == (int)candidate2.Experience;
        }

        public static bool operator !=(Candidate candidate1, Candidate candidate2)
        {
            return (int)candidate1.Experience != (int)candidate2.Experience;
        }

        public override bool Equals(object obj)
        {
            if (obj is Candidate)
            {
                if ((int)((Candidate)obj).Experience == (int)Experience) 
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ((int)Experience).GetHashCode();
        }
    }
}