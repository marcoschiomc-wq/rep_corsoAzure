namespace LibreriaCalcolatrice
{
    public class Calcolatrice
    {
        public IClock clock { get; set; }
        public Calcolatrice(IClock _clock)
        {
            this.clock = _clock;
        }

        public int Somma(int a, int b)
        {
            DateTime oggi = clock.Now();
            var giorno = oggi.DayOfWeek;
            if (giorno != DayOfWeek.Tuesday)
                return a + b;
            else
                return (a * a) + (b * b);
        }
    }
}
