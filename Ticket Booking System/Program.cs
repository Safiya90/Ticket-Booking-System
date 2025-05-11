namespace Ticket_Booking_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketSystem ticket = new TicketSystem();

            ticket.AddTicket(new Ticket("Event1", "A1", TicketType.Regular));
            ticket.AddTicket(new Ticket("Event2", "A2", TicketType.VIP));
            ticket.AddTicket(new Ticket("Event2", "A2", TicketType.Backstage));

            Ticket t = ticket["A2"];
            if (t != null)
            {
                Console.WriteLine("Ticket Info for Seat A2:");
                Console.WriteLine("Event: " + t.EventName);
                Console.WriteLine("Type: " + t.Type);
            }

            Console.WriteLine("\nTicket Counts:");
            ticket.Count();
        }
    }
    enum TicketType
    {
        Regular,
        VIP,
        Backstage
    }

    class Ticket
    {
        public string EventName { get; set; }
        public string SeatNumber { get; set; }
        public TicketType Type { get; set; }

        public Ticket(string eventName, string seatNumber, TicketType type)
        {
            EventName = eventName;
            SeatNumber = seatNumber;
            Type = type;
        }
    
    }
    class TicketSystem
    {
        private Ticket[] tickets = new Ticket[10];
        private int count = 0;

        public void AddTicket(Ticket ticket)
        {
            tickets[count] = ticket;
            count++;
        }
        public Ticket this[string seatNumber]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (tickets[i].SeatNumber == seatNumber)
                        return tickets[i];
                }
                return null;
            }
        }
        public void Count()
        {
            int regular = 0, vip = 0, backstage = 0;

            for (int i = 0; i < count; i++)
            {
                if (tickets[i].Type == TicketType.Regular)
                    regular++;
                else if (tickets[i].Type == TicketType.VIP)
                    vip++;
                else if (tickets[i].Type == TicketType.Backstage)
                    backstage++;
            }

            Console.WriteLine("Regular: " + regular);
            Console.WriteLine("VIP: " + vip);
            Console.WriteLine("Backstage: " + backstage);
        }
    }

}