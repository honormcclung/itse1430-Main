/*
 * ITSE 1430 
 * Lab 2
 * Honor McClung
 * Date: 10/21/22
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honor.CharacterCreator
{
    /// <summary>Defines what a character is.</summary>
    public class Character
    {
        public Character ( string Name, string Race, string Profession, string Biography, int Strength, int Intellingence, int Agility, int Constitution, int Charisma )
        {
            this.Name = Name;
            this.Profession = Profession;
            this.Biography = Biography;
            this.Race = Race;
            this.Strength = Strength;
            this.Intellingence = Intellingence;
            this.Agility = Agility;
            this.Constitution = Constitution;
            this.Charisma = Charisma;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = (!String.IsNullOrWhiteSpace(value)) ? value : throw new ArgumentException("Name must not be blank");
        }

        private string _biography;
        public string Biography
        {
            get => _biography;
            set {
                _biography = value;
            }
        }

        private string _profession;
        public string Profession
        {
            get => _profession;
            set => _profession = value;
        }

        private string _race;
        public string Race
        {
            get => _race;
            set => _race = value;
        }

        private int _strength;

        public int Strength
        {
            get => _strength;
            set => _strength = value;
        }

        private int _intellingence;

        public int Intellingence
        {
            get => _intellingence;
            set => _intellingence = value;
        }

        private int _agility;

        public int Agility
        {
            get => _agility;
            set => _agility = value;
        }

        private int _constitution;

        public int Constitution
        {
            get => _constitution;
            set => _constitution = value;
        }

        private int _charisma;

        public int Charisma
        {
            get => _charisma;
            set => _charisma = value;
        }


    }
}
