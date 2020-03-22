using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public sealed class FileService : IFileService
    {
        public async Task<IEnumerable<BinaryFile>> AddAsync(string directory, IEnumerable<BinaryFile> files)
        {
            return await files.SaveAsync(directory);
        }

        public async Task<BinaryFile> GetAsync(string directory, Guid id)
        {
            return await BinaryFile.ReadAsync(directory, id);
        }
    }
}
