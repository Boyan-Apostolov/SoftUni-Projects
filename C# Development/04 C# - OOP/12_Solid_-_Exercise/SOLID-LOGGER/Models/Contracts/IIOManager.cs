using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_LOGGER.Models.Contracts
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        void EnsureDirectoryAndFileExists();

        string GetCurrentPath();
    }
}
