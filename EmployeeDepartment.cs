namespace hwLesson16
{
    static class EmployeeDepartment
    {
        public static bool ApproveApplication(string name)
        {
            return !name.Contains('P');
        }

        public static double GetSalary(double experience) =>
            20000 + (200 / experience);

        public static Candidate FilterCandidate(Candidate candidate1, Candidate candidate2)
        {
            int result = candidate1.CompareTo(candidate2);
            
            switch (result)
            {
                case 1: 
                    return candidate1;
                case -1: 
                    return candidate2;
                default:
                    return candidate1;
            }
        }
    }
}