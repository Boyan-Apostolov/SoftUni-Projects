﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}