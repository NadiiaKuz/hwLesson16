namespace hwLesson16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Candidate[] candidates = new[]
            {
                new Candidate("Maria", 2006, 2.1), // Must be error age
                new Candidate("Paul", 2000, 3.2), // Not approved
                new Candidate("Mark", 1997, 0.3),
                new Candidate("Sarah", 1999, 5.6),
                new Candidate("Sonya", 2000, 7),
                new Candidate("John", 1977, 15.2),
                new Candidate("Mona", 1967, 15), // Must get job
                new Candidate("Connor", 1999, 5)
            };

            Candidate bestCandidate = null;

            foreach (var candidate in candidates)
            {
                try
                {
                    bool isApproved = EmployeeDepartment.ApproveApplication(candidate.Name);

                    if (isApproved)
                    {
                        CheckAge(candidate.YearOfBirth);

                        if (bestCandidate is null)
                        {
                            bestCandidate = candidate;
                            continue;
                        }

                        var bestCandidateOld = bestCandidate;

                        bestCandidate = EmployeeDepartment.FilterCandidate(bestCandidate, candidate);

                        var declinedCandidate = candidate;

                        if (bestCandidate.Name.Equals(candidate.Name) && (int)bestCandidate.Experience == (int)candidate.Experience)
                            declinedCandidate = bestCandidateOld;

                        MailSender.SendMessageDecline(declinedCandidate);
                    }
                    else
                    {
                        MailSender.SendMessageDecline(candidate);
                    }
                }
                catch (TooYoungExeption ex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ERROR: {ex.Message} Age {ex.Age}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }


            }

            if (bestCandidate is null)
            {
                Console.WriteLine("ERROR: There is no good candidate");
                return;
            }

            double salary = EmployeeDepartment.GetSalary(bestCandidate.Experience);

            MailSender.SendMessageConfirmation(bestCandidate, salary);
        }

        private static void CheckAge(int yearOfBirth)
        {
            byte age = Convert.ToByte(DateTime.Now.Year - yearOfBirth);

            if (age < 18)
                throw new TooYoungExeption(age);
        }
    }
}