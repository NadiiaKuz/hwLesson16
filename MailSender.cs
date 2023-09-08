namespace hwLesson16
{
    static class MailSender
    {
        public static void SendMessageConfirmation(Candidate candidate, double salary) =>
            Console.WriteLine($"MESSAGE SENT: Congratulations {candidate.Name}, you've been hired with salary: {salary}");

        public static void SendMessageDecline(Candidate candidate) =>
            Console.WriteLine($"MESSAGE SENT: Sorry {candidate.Name}, you did not get a job");
    }
}