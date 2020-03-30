using System.Collections.Generic;
using System.IO;
using System.Net;
using ToyLanguage.Model;

namespace ToyLanguage.RepositoryPack
{
    public class Repository: RepositoryInterface
    {
        private List<ProgramState> programs;

        public Repository()
        {
            programs = new List<ProgramState>();
        }

        public Repository(List<ProgramState> programs)
        {
            this.programs = programs;
        }
        
        public ProgramState getCurrentProgram()
        {
            return programs[0];
        }

      
    }
}