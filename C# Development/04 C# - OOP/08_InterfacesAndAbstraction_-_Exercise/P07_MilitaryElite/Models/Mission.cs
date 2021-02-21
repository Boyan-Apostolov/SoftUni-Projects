using System;
using System.Collections.Generic;
using System.Text;
using P07_MilitaryElite.Contracts;
using P07_MilitaryElite.Enumberations;

namespace P07_MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codename,string state)
        {
            this.CodeName = codename;
            this.State = this.TryParseState(state);
        }
        public string CodeName { get; private set; }
        public State State { get; private set; }
        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new ArgumentException("Mission already completed!");
            }

            this.State = State.Finished;
        }

        private State TryParseState(string stateStr)
        {
            State state;
            bool parsed = Enum.TryParse<State>(stateStr,out state);
            if (!parsed)
            {
                throw new ArgumentException("Invalid mission state!");
            }

            return state;
        }
    }
}
