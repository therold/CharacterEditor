using System;
using System.Collections.Generic;
using System.Text;

namespace TBH.DND.Android.Models
{
    public static class FilterLists
    {
        public enum Source
        {
            PHB,
            XGE,
            TCE,
            //SCAG,
            //Eberron,
            //AcquisitionsIncorporated,
            //RimeOfTheFrostmaiden,
            //MythicOdysseysOfTheros,
            //Strixhaven,
            //ExplorerSGuideToWildemount,
            //VanRichtensGuideToRavenloft
        }

        public enum DndClass
        {
            Artificer = 1,
            Bard = 2,
            Cleric = 4,
            Druid = 8,
            Monk = 16,
            Paladin = 32,
            Ranger = 64,
            Sorcerer = 128,
            Warlock = 256,
            Wizard = 512,
        }

        public enum Race
        { 
            Dwarf = 1,
            Elf = 2,
            Halfling = 4,
            Human = 8,
            Dragonborn = 16,
            Gnome = 32,
            HalfElf = 64,
            HalfOrc = 128,
            Tiefling = 256
        }

        public enum Background
        {
            Acolyte = 1,
            Charlatan = 2,
            Criminal = 4,
            Entertainer = 8,
            GuildArtisan = 16,
            Hermit = 32,
            Noble = 64,
            Outlander = 128,
            Sage = 256,
            Sailor = 512,
            Soldier = 1024,
            Urchin = 2048
        }
    }
}
