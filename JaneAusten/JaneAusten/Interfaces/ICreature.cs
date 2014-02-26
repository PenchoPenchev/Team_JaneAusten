namespace JaneAusten
{
    using System;

    public interface ICreature
    {
        int Lifes { get; set; }

        ConsoleColor Color { get; set; }

        int Health { get; set; }

        int Speed { get; set; }

        bool CollideWithMovingObject(Level level);
    }
}
