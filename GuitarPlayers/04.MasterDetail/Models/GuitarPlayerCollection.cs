using System;
using System.Collections.Generic;

namespace GuitarPlayers.Models
{
    public class GuitarPlayerCollection : ICollection<GuitarPlayer>
    {
        private readonly List<GuitarPlayer> guitarPlayers;

        public GuitarPlayerCollection()
        {
            this.guitarPlayers = new List<GuitarPlayer>();
        }

        private static GuitarPlayerCollection players;
        public static GuitarPlayerCollection Players
        {
            get
            {
                return players ?? (players = new GuitarPlayerCollection
                {
                    new GuitarPlayer{ FirstName = "Charles",    LastName = "McAuley",   YearOfBirth = 1955},
                    new GuitarPlayer{ FirstName = "Jimi",       LastName = "Hendrix",   YearOfBirth = 1942},
                    new GuitarPlayer{ FirstName = "Eric",       LastName = "Clapton",   YearOfBirth = 1945},
                    new GuitarPlayer{ FirstName = "Eddie",      LastName = "Van Halen", YearOfBirth = 1955},
                    new GuitarPlayer{ FirstName = "Pat",        LastName = "Metheny",   YearOfBirth = 1954},
                    new GuitarPlayer{ FirstName = "Robert",     LastName = "Cray",      YearOfBirth = 1953},
                    new GuitarPlayer{ FirstName = "Carlos",     LastName = "Santana",   YearOfBirth = 1947},
                    new GuitarPlayer{ FirstName = "Rory",       LastName = "Gallagher", YearOfBirth = 1948},
                    new GuitarPlayer{ FirstName = "Mark",       LastName = "Knopfler",  YearOfBirth = 1949},
                    new GuitarPlayer{ FirstName = "Jimmy",      LastName = "Page",      YearOfBirth = 1944}
                });
            }
        }

        public void Add(GuitarPlayer item)
        {
            this.guitarPlayers.Add(item);
        }

        public void Clear()
        {
            this.guitarPlayers.Clear();
        }

        public bool Contains(GuitarPlayer item)
        {
            return this.guitarPlayers.Contains(item);
        }

        public void CopyTo(GuitarPlayer[] array, int arrayIndex)
        {
            this.guitarPlayers.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.guitarPlayers.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(GuitarPlayer item)
        {
            return this.guitarPlayers.Remove(item);
        }

        public IEnumerator<GuitarPlayer> GetEnumerator()
        {
            return this.guitarPlayers.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.guitarPlayers.GetEnumerator();
        }

        public void ForEach(Action<GuitarPlayer> action)
        {
            this.guitarPlayers.ForEach(action);
        }
    }
}
