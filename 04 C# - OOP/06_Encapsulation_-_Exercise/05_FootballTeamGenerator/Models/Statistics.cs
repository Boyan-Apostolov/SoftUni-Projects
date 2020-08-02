﻿using System;
using System.Collections.Generic;
using System.Text;
using _05_FootballTeamGenerator.Common;

namespace _05_FootballTeamGenerator.Models
{
    public class Statistics
    {
        private const int STAT_MIN_VALUE = 0;
        private const int STAT_MAX_VALUE = 100;
        private const double STAST_COUNT = 5.0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Statistics(int endurance,int sprint,int dribble,int passing,int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                ValidateStat(value,nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                this.ValidateStat(value,nameof(this.Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                this.ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                this.ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                this.ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double AverageStat() => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / STAST_COUNT;
        

        private void ValidateStat(int value,string statName)
        {
            if (value < STAT_MIN_VALUE || value > STAT_MAX_VALUE)
            {
                throw new ArgumentException(string.Format(GlobalConstants.InvalidStatMSG, statName,
                    STAT_MIN_VALUE, STAT_MAX_VALUE));
            }
        }
    }
}
