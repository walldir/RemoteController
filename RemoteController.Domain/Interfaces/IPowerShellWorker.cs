namespace RemoteController.Domain.Interfaces
{
    public interface IPowerShellWorker
    {
        void ReadInput(string command);
        void ReadOutput();
    }
}
