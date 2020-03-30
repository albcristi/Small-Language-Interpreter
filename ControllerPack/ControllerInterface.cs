using ToyLanguage.Model;

namespace ToyLanguage.ControllerPack
{
    public interface ControllerInterface
    {
        ProgramState oneStep(ProgramState prg);

        void allStep();
    }
}