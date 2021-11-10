
using System;
using System.Text;

namespace Problems
{
    class CommandContext
    {
        public CommandContext()
        {

        }
    }

    interface ICommand
    {
        public void Run();
    }

    abstract class Command : ICommand
    {
        public CommandContext _CommandContext;
        public Command(CommandContext commandContext)
        {
            this._CommandContext = commandContext;
        }

        public abstract void Run();
    }

    class LibCommand1 : Command
    {

        public LibCommand1(LibraryCommandContext commandContext) : base(commandContext)
        {
            this._CommandContext = commandContext;
        }


        public override void Run()
        {
            ((LibraryCommandContext)this._CommandContext).JobId = 10;
        }
    }

    class LibCommand2 : Command
    {

        public LibCommand2(LibraryCommandContext commandContext) : base(commandContext)
        {
            this._CommandContext = commandContext;
        }


        public override void Run()
        {
            Console.WriteLine(((LibraryCommandContext)this._CommandContext).JobId);
            ((LibraryCommandContext)this._CommandContext).JobName = "Aashish";
        }
    }

    class LibCommand3 : Command
    {

        public LibCommand3(LibraryCommandContext commandContext) : base(commandContext)
        {
            this._CommandContext = commandContext;
        }


        public override void Run()
        {
            Console.WriteLine(((LibraryCommandContext)this._CommandContext).JobName);
        }
    }

    class LibraryCommandContext: CommandContext
    {
        public int JobId { get; set; }
        public string JobName { get; set; }

        public LibraryCommandContext()
        {

        }
    }


    public class Orchestrator
    {

        public void Execute()
        {
            var libraryCommandContext = new LibraryCommandContext();

            var lc1 = new LibCommand1(libraryCommandContext);
            var lc2 = new LibCommand2(libraryCommandContext);
            var lc3 = new LibCommand3(libraryCommandContext);

            lc1.Run();
            lc2.Run();
            lc3.Run();

            Console.WriteLine("All done!");
        }
    }
}