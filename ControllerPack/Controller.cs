using System;
using System.IO;
using ToyLanguage.Model;
using ToyLanguage.RepositoryPack;

namespace ToyLanguage.ControllerPack
{
    public class Controller : ControllerInterface
    {
        private RepositoryInterface repo;
        private String logFileName;

        public Controller(RepositoryInterface repo, string logFileName)
        {
            this.repo = repo;
            this.logFileName = logFileName;
        }

        public Controller(RepositoryInterface repo)
        {
            this.repo = repo;
            logFileName = "notunique.txt";
        }

        public ProgramState oneStep(ProgramState prg)
        {
            if (prg.GetExeStack().Count == 0)
            {
                throw new Exception("Empty Stack!");
            }
            return prg.GetExeStack().Pop().execute(prg);
        }

        public void allStep()
        {
            
            ProgramState prg = this.repo.getCurrentProgram();
            Console.WriteLine("x-----x----------x----------------x----------------------------------------x");
            Console.WriteLine(prg.ToString());
            File.AppendAllText(logFileName,prg.ToString());
            while (prg.GetExeStack().Count > 0)
            {
                oneStep(prg);
                Console.WriteLine(prg.ToString());
                File.AppendAllText(logFileName,prg.ToString());
                Console.WriteLine("x-----x----------x----------------x----------------------------------------x");
            }
        }
    }
}