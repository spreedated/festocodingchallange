using System;
using System.ComponentModel;

namespace CodingChallange2022.Models
{
    internal record SecurityLogRecord
    {
        public enum Places
        {
            Unknown,
            [Description("Bio-Lab")]
            BioLab,
            [Description("Factory")]
            Factory,
            [Description("Shopping Mall")]
            ShoppingMall,
            [Description("Food Plant")]
            FoodPlant,
            [Description("Office Station")]
            OfficeStation,
            [Description("Gym")]
            Gym,
            [Description("Starship Garage")]
            StarshipGarage,
            [Description("Happy-Center")]
            HappyCenter,
            [Description("Palace")]
            Palace,
            [Description("Junkyard")]
            Junkyard,
            [Description("Pod Racing Track")]
            PodRacingTrack,
            [Description("Mining Outpost")]
            MiningOutpost
        }
        public TimeOnly Time { get; set; }
        public string[] InNames { get; set; }
        public string[] OutNames { get; set; }
        public Places Place { get; set; }
    }
}
