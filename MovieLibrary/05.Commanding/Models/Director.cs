﻿namespace MovieLibrary.Models
{
    /// <summary>
    /// oqiasjf;ojas;odfh
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Director : IDirector
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return "<< " + Name + " >>";
        }
    }
}
